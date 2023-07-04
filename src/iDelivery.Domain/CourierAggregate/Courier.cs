using iDelivery.Domain.CommandAggregate.ValueObjects;
using iDelivery.Domain.AccountAggregate.Entities;
using iDelivery.Domain.AccountAggregate.ValueObjects;
using iDelivery.Domain.Common.Utilities;
using iDelivery.Domain.CourierAggregate.Entities;
using iDelivery.Domain.CourierAggregate.ValueObjects;
using iDelivery.Domain.SupervisorAggregate.ValueObjects;

namespace iDelivery.Domain.CourierAggregate;

public sealed class Courier : User
{
    // private List<Delivery> _deliveries = new();
    // private List<CommandId> _commandIds = new();
    // public IReadOnlyList<Delivery> Deliveries => _deliveries.AsReadOnly();
    // public IReadOnlyList<CommandId> CommandIds => _commandIds.AsReadOnly();
    public SupervisorId SupervisorId{ get; private set; }
    private Courier(
        CourierId id,
        Email email,
        Password password,
        string name,
        string role,
        PhoneNumber phoneNumber,
        SupervisorId supervisorId,
        AccountId accountId) : base(
            id,
            email,
            password,
            name,
            phoneNumber,
            role,
            accountId)
    {
        SupervisorId = supervisorId;
    }

    #pragma warning disable CS8618
    private Courier()
    {

    }
    #pragma warning restore CS8618

    public void AddCommand(CommandId commandId)
    {
        // _commandIds.Add(commandId);
    }
    public void RemoveCommand(CommandId commandId)
    {
        // _commandIds.Remove(commandId);
    }

    public static Courier Create (
        Email email,
        Password password,
        string name,
        PhoneNumber phoneNumber,
        Guid supervisorId,
        AccountId accountId)
    {
        return new Courier(
            CourierId.CreateUnique(),
            email,
            password,
            name,
            Roles.Runner,
            phoneNumber,
            SupervisorId.Create(supervisorId),
            accountId);
    }
}
