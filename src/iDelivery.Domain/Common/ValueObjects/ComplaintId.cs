using iDelivery.Domain.AccountAggregate.ValueObjects;

namespace iDelivery.Domain.Common.ValueObjects;
public sealed class ComplaintId : UserId
{
    private ComplaintId(Guid id) : base(id)
    {
        Value = id;
    }
    private ComplaintId()
    {

    }
    public static new ComplaintId Create(Guid id)
    {
        return new(id);
    }
    public static new ComplaintId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
