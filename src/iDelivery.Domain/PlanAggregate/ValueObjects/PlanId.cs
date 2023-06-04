namespace iDelivery.Domain.PlanAggregate.ValueObjects;
public sealed class PlanId : ValueObject
{
    public Guid Id { get; private set; }
    private PlanId(Guid id)
    {
        Id = id;
    }
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Id;
    }
    public static PlanId CreateUnique()
    {
        return new(Guid.NewGuid());
    }
    public static PlanId Create(Guid id)
    {
        return new(id);
    }
}