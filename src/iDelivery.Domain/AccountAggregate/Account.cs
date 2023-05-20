using iDelivery.Domain.AccountAggregate.Enums;
using iDelivery.Domain.AccountAggregate.ValueObjects;

namespace iDelivery.Domain.AccountAggregate;

public sealed class Account : AggregateRoot<AccountId>
{
    public Email Email { get; set; }
    public Password Password { get; set; }
    public AccountType Type { get; set; }
    public string Name { get; set; }
    public PhoneNumber PhoneNumber { get; set; }
    public string ApiKey { get; set; }

    private Account(
        AccountId id,
        Email email,
        Password password,
        AccountType type,
        string name,
        PhoneNumber phoneNumber,
        string apiKey) : base(id)
    {
        Email = email;
        Password = password;
        Type = type;
        Name = name;
        PhoneNumber = phoneNumber;
        ApiKey = apiKey;
    }

    public static Account Create(
        string email,
        string password,
        AccountType type,
        string name,
        int phoneNumber,
        string apiKey)
    {
        return new Account(
            AccountId.CreateUnique(),
            Email.Create(email),
            Password.Create(password),
            type,
            name,
            PhoneNumber.Create(phoneNumber),
            apiKey);
    }
}
