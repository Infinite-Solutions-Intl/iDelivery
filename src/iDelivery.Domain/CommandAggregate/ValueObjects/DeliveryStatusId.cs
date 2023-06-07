namespace iDelivery.Domain.CommandAggregate.ValueObjects;
public sealed class DeliveryStatusId : ValueObject
{
    public Guid Id { get; }
    private DeliveryStatusId(Guid id)
    {
        Id = id;
    }
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Id;
    }
    public static DeliveryStatusId CreateUnique()
    {
        return new(Guid.NewGuid());
    }
    public static DeliveryStatusId Create(Guid id)
    {
        return new(id);
    }
}
