using iDelivery.Domain.AccountAggregate.ValueObjects;

namespace iDelivery.Domain.Common.ValueObjects;
public sealed class PartnerId : UserId
{
    private PartnerId(Guid value) : base(value)
    {
        Value = value;
    }
    public static new PartnerId Create(Guid value)
    {
        return new(value);
    }
    public static new PartnerId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
