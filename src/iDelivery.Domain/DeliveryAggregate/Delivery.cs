using iDelivery.Domain.DeliveryAggregate.ValueObjects;

namespace iDelivery.Domain.DeliveryAggregate;
public sealed class Delivery : AggregateRoot<DeliveryId>
{
    public Delivery(DeliveryId id) : base(id)
    {
    }
}