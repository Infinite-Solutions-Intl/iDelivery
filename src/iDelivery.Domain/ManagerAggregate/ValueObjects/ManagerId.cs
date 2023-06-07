using iDelivery.Domain.AccountAggregate.ValueObjects;

namespace iDelivery.Domain.ManagerAggregate.ValueObjects;
public sealed class ManagerId : UserId
{
    private ManagerId(Guid id) : base(id)
    {
        Id = id;
    }
    public static new ManagerId Create(Guid id)
    {
        return new(id);
    }
    public static new ManagerId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Id;
    }
}
