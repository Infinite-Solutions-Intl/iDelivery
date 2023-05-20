namespace iDelivery.Infrastructure.Authentication;

public sealed class JwtSettings
{
    public string Issuer { get; set; } = null!;
    public string Audience { get; set; } = null!;
    public int ExpirationInDays { get; set; }
    public string SecretKey { get; set; } = null!;
}
