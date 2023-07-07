using iDelivery.Application.Authentication.Services;
using System.Security.Claims;

namespace iDelivery.Application.Authentication.Login;

internal class LoginQueryHandler : IRequestHandler<LoginQuery, Result<LoginQueryResponse>>
{
    private readonly IJwtTokenGenerator _tokenGenerator;
    private readonly IAccountRepository _accountRepository;

    public LoginQueryHandler(
        IJwtTokenGenerator tokenGenerator,
        IAccountRepository accountRepository)
    {
        _tokenGenerator = tokenGenerator;
        _accountRepository = accountRepository;
    }

    public async Task<Result<LoginQueryResponse>> Handle(LoginQuery request, CancellationToken cancellationToken)
    {
        // Get the specified User
        AccountId accountId = AccountId.Create(request.AccountId);
        User? user = await _accountRepository.FindUserAsync(
            accountId,
            Email.Create(request.Email),
            Password.Create(request.Password));

        if(user is null)
            return Result.Fail<LoginQueryResponse>(new UserNotFoundError());

        // Generate the JWT Token
        var claims = new []
        {
            new Claim(ClaimTypes.Email, user.Email.Value),
            new Claim(ClaimTypes.NameIdentifier, user.Name),
            new Claim(ClaimTypes.Hash, user.Password.Value),
            new Claim(ClaimTypes.Role, user.Role)
        };

        string token = _tokenGenerator.GenerateToken(claims);

        return new LoginQueryResponse(token);
    }
}
