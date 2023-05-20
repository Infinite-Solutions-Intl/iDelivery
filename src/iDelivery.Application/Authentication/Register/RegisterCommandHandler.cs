using System.Security.Claims;
using iDelivery.Application.Authentication.Services;
using iDelivery.Application.Repositories;
using iDelivery.Domain.AccountAggregate;
using iDelivery.Domain.AccountAggregate.ValueObjects;
using MapsterMapper;
using MediatR;

namespace iDelivery.Application.Authentication.Register;

internal class RegisterCommandHandler : IRequestHandler<RegisterCommand, RegisterCommandResponse>
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

    public async Task<RegisterCommandResponse> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        // Check if the email already exists
        if(await _accountRepository.ExistsAsync(Email.Create(request.Email), cancellationToken))
            throw new Exception();

        // Generate the API Key
        var claims = new[]
        {
            new Claim(ClaimTypes.Email, request.Email),
            new Claim(ClaimTypes.Name, request.Name),
            new Claim(ClaimTypes.MobilePhone, request.PhoneNumber.ToString())
        };

        string key = _keyGenerator.GenerateApiKey(claims);

        Account account = _mapper.Map<Account>((request, key));

        // Save the new Account
        _ = await _accountRepository.AddAsync(account, cancellationToken);

        // TODO: Raise the AccountCreatedEvent

        // Return 
        return _mapper.Map<RegisterCommandResponse>(account);
    }
}
