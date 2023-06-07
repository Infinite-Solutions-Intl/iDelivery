using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using iDelivery.Application.Authentication.Services;

namespace iDelivery.Infrastructure.Authentication;

public sealed class ApiKeyGenerator : IApiKeyGenerator
{
    private const int _keySize = 128;

    public string GenerateApiKey(IEnumerable<Claim> claims)
    {
        // Create the random key
        var apiKey = GenerateRandomApiKey();

        // Combine with the different claims
        foreach(var claim in claims)
            apiKey += $"|{claim.Value}";

        // Encrypt the API key using AES encryption

        return EncryptKey(apiKey);
    }

    private static string GenerateRandomApiKey()
    {
        var keyBytes = new byte[_keySize / 8];
        RandomNumberGenerator randomNumberGenerator = RandomNumberGenerator.Create();
        randomNumberGenerator.GetBytes(keyBytes);

        return Convert.ToBase64String(keyBytes);
    }

    private static string EncryptKey(string apiKey)
    {
        // Copied from Google
        var aesAlg = Aes.Create();
        aesAlg.KeySize = _keySize;
        aesAlg.GenerateKey();
        aesAlg.GenerateIV();

        var encryptor =aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

        using var msEncrypt = new MemoryStream();
        using var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write);

        var apiKeyBytes = Encoding.UTF8.GetBytes(apiKey);
        csEncrypt.Write(apiKeyBytes, 0, apiKeyBytes.Length);

        csEncrypt.FlushFinalBlock();

        var encryptedKeyBytes = msEncrypt.ToArray();
        return Convert.ToBase64String(encryptedKeyBytes);
    }
}
