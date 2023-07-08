using System.Security.Cryptography;
using System.Text;
using iDelivery.Application.Utilities;
using Microsoft.Extensions.Configuration;

namespace iDelivery.Infrastructure.Utilities;

public sealed class HashEngine : IHashEngine
{
    private readonly string _salt;

    public HashEngine(IConfiguration configuration)
    {
        _salt = string.Empty;
        string configPath = configuration.GetValue("ConfigFile", string.Empty);
        try
        {
            // To gather from a config file
            if (File.Exists(configPath))
                _salt = File.ReadAllText(configPath);
            else
            {
                var stream = File.Create(configPath);
                string salt = $"{Random.Shared.Next(10000)}-iDelivery";
                _salt = salt;
                byte[] buffer = Encoding.UTF8.GetBytes(salt);
                stream.Write(buffer, 0, buffer.Length);
                stream.Close();
            }
        }
        catch (Exception)
        {
            _salt = string.Empty;
        }
    }

    public string Hash(string key)
    {
        var saltedPassword = string.Concat(_salt, key, _salt);
        var textBytes = Encoding.UTF8.GetBytes(saltedPassword);
        var hash = SHA512.Create().ComputeHash(textBytes);
        return Convert.ToBase64String(hash);
    }
}
