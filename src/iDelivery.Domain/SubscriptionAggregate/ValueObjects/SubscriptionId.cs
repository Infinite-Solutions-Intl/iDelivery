namespace iDelivery.Domain.SubscriptionAggregate.ValueObjects;
public sealed class SubscriptionId : ValueObject
{
    public Guid Id { get; }
    private SubscriptionId(Guid id)
    {
        Id = id;
    }
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Id;
    }
    public static SubscriptionId CreateUnique()
    {
        return new(Guid.NewGuid());
    }
    public static SubscriptionId Create(Guid id)
    {
        return new(id);
    }
}
