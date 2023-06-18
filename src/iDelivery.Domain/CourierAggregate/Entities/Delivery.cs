using iDelivery.Domain.CommandAggregate.ValueObjects;
using iDelivery.Domain.CourierAggregate.ValueObjects;

namespace iDelivery.Domain.CourierAggregate.Entities;

public sealed class Delivery : AggregateRoot<DeliveryId>
{
    private readonly List<CommandId> _commandIds = new();
    public IReadOnlyList<CommandId> CommandIds => _commandIds.AsReadOnly();
    private  Delivery(DeliveryId courseId) : base(courseId)
    {

    }

    private Delivery()
    {
    }

    public static Delivery Create()
    {
        return new Delivery(DeliveryId.CreateUnique());
    }
}
