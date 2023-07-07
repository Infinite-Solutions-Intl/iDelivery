using iDelivery.Domain.AccountAggregate.Entities;
using iDelivery.Domain.AccountAggregate.ValueObjects;
using iDelivery.Domain.Common.Utilities;
using iDelivery.Domain.CourierAggregate.ValueObjects;
using iDelivery.Domain.ManagerAggregate;
using iDelivery.Domain.ManagerAggregate.ValueObjects;
using iDelivery.Domain.SupervisorAggregate.ValueObjects;

namespace iDelivery.Domain.SupervisorAggregate;

public sealed class Supervisor : User
{
    private readonly List<CourierId> _courierIds = new();
    public IReadOnlyList<CourierId> CourierIds => _courierIds.AsReadOnly();

    private Supervisor(
        UserId id,
        Email email,
        Password password,
        string name,
        string role,
        PhoneNumber phoneNumber,
        AccountId accountId) : base(
            id,
            email,
            password,
            name,
            phoneNumber,
            role,
            accountId)
    {
    }

    private Supervisor()
    {

    }

    public static Supervisor Create(
        Email email,
        Password password,
        string name,
        PhoneNumber phoneNumber,
        AccountId accountId)
    {
        return new Supervisor(
            SupervisorId.CreateUnique(),
            email,
            password,
            name,
            Roles.Supervisor,
            phoneNumber,
            accountId);
    }

    internal static Supervisor Restore(SupervisorId supervisorId, Email email, Password password, string name, PhoneNumber phoneNumber, AccountId accountId)
    {
        return new Supervisor(
            supervisorId,
            email,
            password,
            name,
            Roles.Supervisor,
            phoneNumber,
            accountId);
    }
}
