using System.Security.Claims;
using iDelivery.Application.Authentication.Services;
using iDelivery.Application.Repositories;
using iDelivery.Domain.AccountAggregate.Entities;
using iDelivery.Domain.AccountAggregate.ValueObjects;
using MapsterMapper;
using MediatR;

namespace iDelivery.Application.Authentication.Login;

internal class LoginQueryHandler : IRequestHandler<LoginQuery, LoginQueryResponse>
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

    public async Task<LoginQueryResponse> Handle(LoginQuery request, CancellationToken cancellationToken)
    {
        // Get the specified User
        User user = await _userRepository.FindUserAsync(Email.Create(request.Email), Password.Create(request.Password));

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
