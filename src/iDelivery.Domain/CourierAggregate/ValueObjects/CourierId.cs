using iDelivery.Domain.AccountAggregate.ValueObjects;

namespace iDelivery.Domain.CourierAggregate.ValueObjects;
public sealed class CourierId : UserId
{
    private CourierId(Guid value) : base(value)
    {
        Value = value;
    }
    public static new CourierId Create(Guid value)
    {
        return new(value);
    }
    public static new CourierId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
