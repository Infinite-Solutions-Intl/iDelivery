using iDelivery.Domain.AccountAggregate.ValueObjects;
using iDelivery.Domain.SupervisorAggregate.ValueObjects;

namespace iDelivery.Domain.AccountAggregate.Entities;

public class User : Entity<UserId>
{
<<<<<<< HEAD
    private SupervisorId supervisorId;
=======
>>>>>>> 6ba0013 (corrections)

    public Email Email { get; set; }
    public Password Password { get; set; }
    public string Name { get; set; }
    public PhoneNumber PhoneNumber { get; set; }
    public AccountId AccountId{get; set;}

    protected User(UserId id, Email email, Password password, string name, PhoneNumber phoneNumber, AccountId accountId) : base(id)
    {
        Email = email;
        Password = password;
        Name = name;
        PhoneNumber = phoneNumber;
        AccountId = accountId;
    }

<<<<<<< HEAD
    public User(UserId id, Email email, Password password, string name, PhoneNumber phoneNumber, SupervisorId supervisorId) : base(id)
    {
        Email = email;
        Password = password;
        Name = name;
        PhoneNumber = phoneNumber;
        this.supervisorId = supervisorId;
    }

=======
>>>>>>> 6ba0013 (corrections)
    public User(UserId id, Email email, Password password, string name, PhoneNumber phoneNumber) : base(id)
    {
    }

    public User(UserId id) : base(id)
    {
<<<<<<< HEAD
=======
    }

    public User(UserId id, Email email, Password password, string name, PhoneNumber phoneNumber, SupervisorId supervisorId) : this(id, email, password, name, phoneNumber)
    {
>>>>>>> 6ba0013 (corrections)
    }

    public static User Create(
        string email,
        string password,
        string name,
        int phoneNumber,
        Guid accountId)
    {
        return new User(
            UserId.CreateUnique(),
            Email.Create(email),
            Password.Create(password),
            name,
            PhoneNumber.Create(phoneNumber),
            AccountId.Create(accountId));
    }
}
