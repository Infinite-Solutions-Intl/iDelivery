namespace iDelivery.Domain.CourierAggregate.ValueObjects;

public sealed class DeliveryId : ValueObject
{
    public Guid Value { get; set; }
    private DeliveryId(Guid value)
    {
        Value = value;
    }
    private DeliveryId()
    {
    }
    public static DeliveryId Create(Guid value)
    {
        return new DeliveryId(value);
    }
    public static DeliveryId CreateUnique()
    {
        return new DeliveryId(Guid.NewGuid());
    }
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
