using iDelivery.Domain.AccountAggregate.ValueObjects;

namespace iDelivery.Domain.Common.ValueObjects;
public sealed class ReaderId : UserId
{
    private ReaderId(Guid id) : base(id)
    {
        Id = id;
    }
    public static new ReaderId Create(Guid id)
    {
        return new(id);
    }
    public static new ReaderId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Id;
    }
}
