using iDelivery.Domain.AccountAggregate.ValueObjects;
using iDelivery.Domain.CommandAggregate.ValueObjects;
using iDelivery.Domain.CourierAggregate.ValueObjects;

namespace iDelivery.Domain.CourierAggregate.Entities;

public sealed class Delivery : AggregateRoot<DeliveryId>
{
    public UserId CourierId{ get; set; }
    public Courier Courier { get; private set; }
    private readonly List<CommandId> _commandIds = new();
    public IReadOnlyList<CommandId> CommandIds => _commandIds.AsReadOnly();
    private Delivery(
        DeliveryId courseId,
        Courier courier,
        UserId courierId) : base(courseId)
    {
        CourierId = courierId;
        Courier = courier;
    }

#pragma warning disable CS8618
    private Delivery()
    {
    }
#pragma warning restore CS8618

    public static Delivery Create(
        Courier courier)
    {
        return new Delivery(
            DeliveryId.CreateUnique(),
            courier,
            courier.Id);
    }

    public void AddCommand(CommandId commandId)
    {
        _commandIds.Add(commandId);
    }
    
    public void AddRangeCommand(params CommandId[] commandIds)
    {
        _commandIds.AddRange(commandIds);
    }

    public void RemoveCommand(CommandId commandId)
    {
        _commandIds.Remove(commandId);
    }

    public void RemoveRangeCommand(params CommandId[] commandIds)
    {
        _commandIds.RemoveAll(commandIds.Contains);
    }
}
