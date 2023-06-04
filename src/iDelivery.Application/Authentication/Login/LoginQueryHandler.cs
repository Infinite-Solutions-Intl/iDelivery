using FluentResults;
using iDelivery.Application.Authentication.Services;
using iDelivery.Application.Common.Errors;
using System.Security.Claims;

namespace iDelivery.Application.Authentication.Login;

internal class LoginQueryHandler : IRequestHandler<LoginQuery, Result<LoginQueryResponse>>
{
    private readonly IUserRepository _userRepository;
    private readonly IJwtTokenGenerator _tokenGenerator;
    private readonly IMapper _mapper;

    public LoginQueryHandler(
        IUserRepository userRepository,
        IJwtTokenGenerator tokenGenerator,
        IMapper mapper)
    {
        _userRepository = userRepository;
        _tokenGenerator = tokenGenerator;
        _mapper = mapper;
    }

    public async Task<Result<LoginQueryResponse>> Handle(LoginQuery request, CancellationToken cancellationToken)
    {
        // Get the specified User
        User? user = await _userRepository.FindUserAsync(Email.Create(request.Email), Password.Create(request.Password));
        if(user is null)
            return Result.Fail<LoginQueryResponse>(new UserNotFoundError());

        // Generate the JWT Token
        var claims = new []
        {
            new Claim(ClaimTypes.Email, user.Email.Value),
            new Claim(ClaimTypes.NameIdentifier, user.Name),
            new Claim(ClaimTypes.Hash, user.Password.Value)
        };

        string token = _tokenGenerator.GenerateToken(claims);

        return _mapper.Map<LoginQueryResponse>((user, token));
    }
}
