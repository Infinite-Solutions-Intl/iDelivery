using iDelivery.Domain.AccountAggregate.ValueObjects;

namespace iDelivery.Domain.ManagerAggregate.ValueObjects;
public sealed class ManagerId : UserId
{
    private ManagerId(Guid value) : base(value)
    {
        Value = value;
    }
    public static new ManagerId Create(Guid value)
    {
        return new(value);
    }
    public static new ManagerId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
