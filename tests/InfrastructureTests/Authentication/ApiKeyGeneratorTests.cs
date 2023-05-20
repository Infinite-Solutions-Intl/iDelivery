using iDelivery.Infrastructure.Authentication;
using System.Security.Claims;

namespace InfrastructureTests.Authentication;

public class ApiKeyGeneratorTests
{
    private readonly ApiKeyGenerator _apiKeyGenerator = new();

    [Fact]
    public void GeneratedKey_ShouldBeUnique()
    {
        var claims = new[]
        {
            new Claim(ClaimTypes.NameIdentifier, "Djoufson"),
            new Claim(ClaimTypes.Email, "djoufson@mail.com")
        };

        var key1 = _apiKeyGenerator.GenerateApiKey(claims);
        var key2 = _apiKeyGenerator.GenerateApiKey(claims);

        Assert.NotEqual(key1, key2);
    }
}