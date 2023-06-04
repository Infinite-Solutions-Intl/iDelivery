using iDelivery.Domain.AccountAggregate.ValueObjects;

namespace iDelivery.Domain.RunnerAggregate.ValueObjects;
public sealed class RunnerId : UserId
{
    private RunnerId(Guid id) : base(id)
    {
        Id = id;
    }
    public static new RunnerId Create(Guid id)
    {
        return new(id);
    }
    public static new RunnerId CreateUnique()
    {
        return new(Guid.NewGuid());
    }
    
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Id;
    }
}
