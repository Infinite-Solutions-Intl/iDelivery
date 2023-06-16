namespace iDelivery.Domain.CommandAggregate.ValueObjects;
public sealed class DeliveryStatusId : ValueObject
{
    public Guid Value { get; private set;}
    private DeliveryStatusId(Guid value)
    {
        Value = value;
    }
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
    public static DeliveryStatusId CreateUnique()
    {
        return new(Guid.NewGuid());
    }
    public static DeliveryStatusId Create(Guid value)
    {
        return new(value);
    }
}
