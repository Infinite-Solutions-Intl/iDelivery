using iDelivery.Domain.Common.Models;

namespace iDelivery.Domain.AccountAggregate.ValueObjects;

public class UserId : ValueObject
{
    public Guid Id { get; protected set; }

    private UserId(Guid id)
    {
        Id = id;
    }

    public static UserId CreateUnique()
    {
        return new UserId(Guid.NewGuid());
    }
    public static UserId Create(Guid id)
    {
        return new UserId(id);
    }
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Id;
    }
}
