using System.Security.Claims;

namespace iDelivery.Application.Authentication.Services;

public interface IJwtTokenGenerator
{
    string GenerateToken(IEnumerable<Claim> claims);
}
