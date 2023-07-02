using FluentResults;
using iDelivery.Application.Authentication.Services;
using System.Security.Claims;

namespace iDelivery.Application.Authentication.Login;

internal class LoginQueryHandler : IRequestHandler<LoginQuery, Result<LoginQueryResponse>>
{
    private readonly IUserRepository _userRepository;
    private readonly IJwtTokenGenerator _tokenGenerator;

    public LoginQueryHandler(
        IUserRepository userRepository,
        IJwtTokenGenerator tokenGenerator)
    {
        _userRepository = userRepository;
        _tokenGenerator = tokenGenerator;
    }

    public async Task<Result<LoginQueryResponse>> Handle(LoginQuery request, CancellationToken cancellationToken)
    {
        // Get the specified User
        User? user = await _userRepository.FindUserAsync(Email.Create(request.Email), Password.CreateHash(request.Password));
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
        // return _mapper.Map<LoginQueryResponse>((user, token));
    }
}
