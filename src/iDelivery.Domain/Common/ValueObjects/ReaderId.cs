using iDelivery.Domain.AccountAggregate.ValueObjects;

namespace iDelivery.Domain.Common.ValueObjects;
public sealed class ReaderId : UserId
{
    private ReaderId(Guid value) : base(value)
    {
        Value = value;
    }
    public static new ReaderId Create(Guid value)
    {
        return new(value);
    }
    public static new ReaderId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
