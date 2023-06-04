using System.Security.Claims;

namespace iDelivery.Application.Authentication.Services;

public interface IApiKeyGenerator
{
    string GenerateApiKey(IEnumerable<Claim> claims);
}
