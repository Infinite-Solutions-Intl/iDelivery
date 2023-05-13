﻿using iDelivery.Domain.AccountAggregate.Exceptions;
using System.Security.Cryptography;
using System.Text;

namespace iDelivery.Domain.AccountAggregate.ValueObjects;

public class Password : ValueObject
{
    private static readonly string _salt;
    public string Value { get; set; }

    static Password()
    {
        _salt = string.Empty;
        // A recuperer depuis un fichier de configurations
    }

    private Password(string hash)
    {
        Value = hash;
    }

    public static Password Create(string password)
    {
        if (!IsValid(password, out var hint)) 
            throw new PasswordNotStrongEnoughtException(hint);
        
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