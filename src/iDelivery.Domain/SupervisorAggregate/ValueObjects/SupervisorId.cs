using iDelivery.Domain.AccountAggregate.ValueObjects;

namespace iDelivery.Domain.SupervisorAggregate.ValueObjects;
public sealed class SupervisorId : UserId
{
    private SupervisorId(Guid id) : base(id)
    {
        Id = id;
    }
    public static new SupervisorId Create(Guid id)
    {
        return new(id);
    }
    public static new SupervisorId CreateUnique()
    {
        return new(Guid.NewGuid());
    }
    
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Id;
    }
}
