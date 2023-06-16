using iDelivery.Domain.AccountAggregate.ValueObjects;

namespace iDelivery.Domain.Common.ValueObjects;
public sealed class SuperAdminId : UserId
{
    private SuperAdminId(Guid value) : base(value)
    {
        Value = value;
    }
    public static new SuperAdminId Create(Guid value)
    {
        return new(value);
    }
    public static new SuperAdminId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
