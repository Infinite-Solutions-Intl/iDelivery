namespace iDelivery.Domain.Common.ValueObjects;
public sealed class SubscriptionId : ValueObject
{
    public Guid Value { get; }
    private SubscriptionId(Guid value)
    {
        Value = value;
    }
    private SubscriptionId()
    {

    }
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
    public static SubscriptionId CreateUnique()
    {
        return new(Guid.NewGuid());
    }
    public static SubscriptionId Create(Guid value)
    {
        return new(value);
    }
}
