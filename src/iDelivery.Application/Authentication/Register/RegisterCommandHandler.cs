using iDelivery.Application.Authentication.Services;
using iDelivery.Domain.AccountAggregate.Enums;
using System.Security.Claims;

namespace iDelivery.Application.Authentication.Register;

internal class RegisterCommandHandler : IRequestHandler<RegisterCommand, Result<RegisterCommandResponse>>
{
    private readonly IMapper _mapper;
    private readonly IApiKeyGenerator _keyGenerator;
    private readonly IAccountRepository _accountRepository;

    public RegisterCommandHandler(
        IMapper mapper,
        IApiKeyGenerator keyGenerator,
        IAccountRepository accountRepository)
    {
        _mapper = mapper;
        _keyGenerator = keyGenerator;
        _accountRepository = accountRepository;
    }

    public async Task<Result<RegisterCommandResponse>> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        // Check if the email already exists
        if(await _accountRepository.ExistsAsync(Email.Create(request.Email), cancellationToken))
            return Result.Fail<RegisterCommandResponse>(new EmailAlreadyExistsError());

        // Generate the API Key
        var claims = new[]
        {
            new Claim(ClaimTypes.Email, request.Email),
            new Claim(ClaimTypes.Name, request.Name),
            new Claim(ClaimTypes.MobilePhone, request.PhoneNumber.ToString())
        };

        string key = _keyGenerator.GenerateApiKey(claims);

        Account account = Account.Create(
            Email.Create(request.Email),
            Password.Create(request.Password),
            AccountType.Premium,
            request.Name,
            PhoneNumber.Create(request.PhoneNumber, request.CountryIdentifier),
            key);

        // Save the new Account
        _ = await _accountRepository.AddAsync(account, cancellationToken);

        // TODO: Raise the AccountCreatedEvent

        // return _mapper.Map<RegisterCommandResponse>(account);
        return new RegisterCommandResponse(account.ApiKey);
    }
}
