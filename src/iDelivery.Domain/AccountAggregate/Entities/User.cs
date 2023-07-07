using iDelivery.Domain.AccountAggregate.ValueObjects;
using iDelivery.Domain.Common.ValueObjects;
using iDelivery.Domain.CourierAggregate;
using iDelivery.Domain.CourierAggregate.ValueObjects;
using iDelivery.Domain.ManagerAggregate;
using iDelivery.Domain.ManagerAggregate.ValueObjects;
using iDelivery.Domain.SupervisorAggregate;
using iDelivery.Domain.SupervisorAggregate.ValueObjects;

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

    public Manager ToManager()
    {
        return Manager.Restore(ManagerId.Create(Id.Value), Email, Password, Name, PhoneNumber, AccountId);
    }

    public Courier ToCourier(Guid supervisorId)
    {
        return Courier.Restore(CourierId.Create(Id.Value), SupervisorId.Create(supervisorId), Email, Password, Name, PhoneNumber, AccountId);
    }

    public Supervisor ToSupervisor()
    {
        return Supervisor.Restore(SupervisorId.Create(Id.Value), Email, Password, Name, PhoneNumber, AccountId);
    }

    public Partner ToPartner(string poBox)
    {
        return Partner.Restore(PartnerId.Create(Id.Value), Email, Password, Name, PhoneNumber, poBox, AccountId);
    }
}
