using iDelivery.Domain.AccountAggregate.ValueObjects;

namespace iDelivery.Domain.AccountAggregate.Entities;

public class User : Entity<UserId>
{
    public Email Email { get; set; }
    public Password Password { get; set; }
    public string Name { get; set; }
    public PhoneNumber PhoneNumber { get; set; }
    public string Role { get; set; }
    public AccountId AccountId { get; set; }

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
