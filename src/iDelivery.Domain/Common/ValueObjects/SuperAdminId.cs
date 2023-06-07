using iDelivery.Domain.AccountAggregate.ValueObjects;

namespace iDelivery.Domain.Common.ValueObjects;
public sealed class SuperAdminId : UserId
{
    private SuperAdminId(Guid id) : base(id)
    {
        Id = id;
    }
    public static new SuperAdminId Create(Guid id)
    {
        return new(id);
    }
    public static new SuperAdminId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Id;
    }
}
