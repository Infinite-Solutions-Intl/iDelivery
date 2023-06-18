namespace iDelivery.Domain.PlanAggregate.ValueObjects;
public sealed class PlanId : ValueObject
{
    public Guid Value { get; }
    private PlanId(Guid value)
    {
        Value = value;
    }

    private PlanId()
    {
        
    }
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
    public static PlanId CreateUnique()
    {
        return new(Guid.NewGuid());
    }
    public static PlanId Create(Guid value)
    {
        return new(value);
    }
}