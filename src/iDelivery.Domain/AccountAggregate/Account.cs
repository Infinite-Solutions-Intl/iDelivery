using iDelivery.Domain.AccountAggregate.Enums;
using iDelivery.Domain.AccountAggregate.ValueObjects;

namespace iDelivery.Domain.AccountAggregate;

public sealed class Account : AggregateRoot<AccountId>
{
    private readonly List<UserId> _userIds = new();
    public Email Email { get; set; }
    public Password Password { get; set; }
    public AccountType Type { get; set; }
    public string Name { get; set; }
    public PhoneNumber PhoneNumber { get; set; }
    public string ApiKey { get; set; }
    public IReadOnlyList<UserId> UserIds => _userIds.AsReadOnly();

    #pragma warning disable CS8618
    private Account()
    {

    }
    #pragma warning restore CS8618
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
        Email email,
        Password password,
        AccountType type,
        string name,
        PhoneNumber phoneNumber,
        string apiKey)
    {
        return new Account(
            AccountId.CreateUnique(),
            email,
            password,
            type,
            name,
            phoneNumber,
            apiKey);
    }

    public void AddUser(UserId userId)
    {
        _userIds.Add(userId);
    }
}
