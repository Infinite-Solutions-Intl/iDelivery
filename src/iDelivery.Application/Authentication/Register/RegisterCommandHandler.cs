using iDelivery.Application.Authentication.Services;
using iDelivery.Domain.AccountAggregate.Enums;
using iDelivery.Domain.Common.Utilities;
using System.Security.Claims;

namespace iDelivery.Application.Authentication.Register;

internal class RegisterCommandHandler : IRequestHandler<RegisterCommand, Result<RegisterCommandResponse>>
{
    private readonly IApiKeyGenerator _keyGenerator;
    private readonly IAccountRepository _accountRepository;
    private readonly IUserService _userService;

    public RegisterCommandHandler(
        IApiKeyGenerator keyGenerator,
        IAccountRepository accountRepository,
        IUserService userService)
    {
        _keyGenerator = keyGenerator;
        _accountRepository = accountRepository;
        _userService = userService;
    }

    public async Task<Result<RegisterCommandResponse>> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        Email email = Email.Create(request.Email);
        // Check if the email already exists
        if (await _accountRepository.ExistsAsync(email, cancellationToken))
            return Result.Fail<RegisterCommandResponse>(new EmailAlreadyExistsError());

        // Generate the API Key
        var claims = new[]
        {
            new Claim(ClaimTypes.Email, request.Email),
            new Claim(ClaimTypes.Name, request.Name),
            // new Claim(ClaimTypes.Expired, DateTime.Now.AddMinutes(5).ToString()),
            new Claim(ClaimTypes.MobilePhone, request.PhoneNumber.ToString())
        };

        string apiKey = _keyGenerator.GenerateApiKey(claims);

        Account account = Account.Create(
            Email.Create(request.Email),
            Password.Create(request.Password),
            AccountType.Premium,
            request.Name,
            PhoneNumber.Create(request.PhoneNumber, request.CountryIdentifier),
            apiKey);

        if (await _userService.ExistsAsync(account.Id, email, cancellationToken))
            return Result.Fail<RegisterCommandResponse>(new EmailAlreadyExistsError());

        User user = User.Create(
            account.Email,
            account.Password,
            "Admin",
            account.PhoneNumber,
            Roles.Admin,
            account.Id
        );

        // Save the new Account
        _ = await _accountRepository.AddAsync(account, cancellationToken);
        _ = await _accountRepository.AddUserAsync(account, user, cancellationToken);

        // TODO: Raise the AccountCreatedEvent

        return new RegisterCommandResponse(account.ApiKey);
    }
}
