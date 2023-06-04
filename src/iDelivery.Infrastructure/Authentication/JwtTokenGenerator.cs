using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using iDelivery.Application.Authentication.Services;
using Microsoft.IdentityModel.Tokens;

namespace iDelivery.Infrastructure.Authentication;

public sealed class JwtTokenGenerator : IJwtTokenGenerator
{
    private readonly JwtSettings _jwtSettings;

    public JwtTokenGenerator(JwtSettings jwtSettings)
    {
        _jwtSettings = jwtSettings;
    }

    public string GenerateToken(IEnumerable<Claim> claims)
    {
        var secret = _jwtSettings.SecretKey;
        var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret));

        var token = new JwtSecurityToken(
            issuer:_jwtSettings.Issuer,
            audience: _jwtSettings.Audience,
            expires: DateTime.Now.AddDays(_jwtSettings.ExpirationInDays),
            claims: claims,
            signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
            );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
