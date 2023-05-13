namespace iDelivery.Domain.AccountAggregate.ValueObjects;

#pragma warning disable CA1067 // Override Object.Equals(object) when implementing IEquatable<T>
public class UserId : ValueObject, IEquatable<UserId>
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

    public bool Equals(UserId? other)
    {
        if (other is null) return false;
        return Id.Equals(other.Id);
    }
}
#pragma warning restore CA1067 // Override Object.Equals(object) when implementing IEquatable<T>