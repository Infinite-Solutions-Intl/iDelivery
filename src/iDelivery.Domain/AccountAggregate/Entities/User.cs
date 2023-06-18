using iDelivery.Domain.AccountAggregate.ValueObjects;

namespace iDelivery.Domain.AccountAggregate.Entities;

public class User : Entity<UserId>
{
    public Email Email { get; private set; }
    public Password Password { get; private set; }
    public string Name { get; private set; }
    public PhoneNumber PhoneNumber { get; private set; }
    public string Role { get; private set; }
    public AccountId AccountId { get; private set; }
    public Account? Account { get; private set; }

    protected User(
        UserId id,
        Email email,
        Password password,
        string name,
        PhoneNumber phoneNumber,
        string role,
        AccountId accountId) : base(id)
    {
        Email = email;
        Password = password;
        Name = name;
        PhoneNumber = phoneNumber;
        Role = role;
        AccountId = accountId;
    }

    #pragma warning disable CS8618
    protected User()
    {

    }
    #pragma warning restore CS8618

    public static User Create(
        Email email,
        Password password,
        string name,
        PhoneNumber phoneNumber,
        string role,
        AccountId accountId)
    {
        return new User(
            UserId.CreateUnique(),
            email,
            password,
            name,
            phoneNumber,
            role,
            accountId);
    }
}
