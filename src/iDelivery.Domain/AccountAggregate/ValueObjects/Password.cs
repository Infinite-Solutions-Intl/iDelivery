using iDelivery.Domain.AccountAggregate.Exceptions;
using System.Security.Cryptography;
using System.Text;

namespace iDelivery.Domain.AccountAggregate.ValueObjects;

public sealed class Password : ValueObject
{
    private static readonly string _salt;
    public string Value { get; private set; }

    static Password()
    {
        _salt = string.Empty;
        try
        {
            // To gather from a config file
            if (File.Exists(Constants.ConfigFilePath))
                _salt = File.ReadAllText(Constants.ConfigFilePath);
            else
            {
                var stream = File.Create(Constants.ConfigFilePath);
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

    private Password(string hash)
    {
        Value = hash;
    }

    #pragma warning disable CS8618
    private Password()
    {
        
    }
    #pragma warning restore CS8618

    public static Password Restore(string password)
    {
        return new Password(password);
    }

    public static Password Create(string password)
    {
        if (!IsValid(password, out var hint))
            throw new PasswordNotStrongEnoughException(hint);

        var hash = HashPassword(password);
        return new Password(hash);
    }

    private static bool IsValid(string password, out string hint)
    {
        hint = "";
        return !string.IsNullOrEmpty(password);
    }

    private static string HashPassword(string password)
    {
        var saltedPassword = string.Concat(_salt, password, _salt);
        var textBytes = Encoding.UTF8.GetBytes(saltedPassword);
        var hash = SHA512.Create().ComputeHash(textBytes);
        return Convert.ToBase64String(hash);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
