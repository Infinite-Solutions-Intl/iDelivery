using iDelivery.Domain.AccountAggregate.ValueObjects;

namespace iDelivery.Domain.SupervisorAggregate.ValueObjects;
public sealed class SupervisorId : UserId
{
    private SupervisorId(Guid value) : base(value)
    {
        Value = value;
    }
    public static new SupervisorId Create(Guid value)
    {
        return new(value);
    }
    public static new SupervisorId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
