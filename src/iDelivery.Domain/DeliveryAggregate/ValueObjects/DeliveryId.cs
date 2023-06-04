namespace iDelivery.Domain.DeliveryAggregate.ValueObjects;
public sealed class DeliveryId : ValueObject
{
    public Guid Id { get; private set; }
    private DeliveryId(Guid id)
    {
        Id = id;
    }
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Id;
    }
    public static DeliveryId CreateUnique()
    {
        return new(Guid.NewGuid());
    }
    public static DeliveryId Create(Guid id)
    {
        return new(id);
    }
}