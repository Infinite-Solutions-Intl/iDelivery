namespace iDelivery.Domain.AccountAggregate.ValueObjects;

public class UserId : ValueObject, IEquatable<UserId>
{
    public Guid Value { get; protected set; }

    protected UserId(Guid value)
    {
        Value = value;
    }

    protected UserId()
    {
        
    }
    public static UserId CreateUnique()
    {
        return new UserId(Guid.NewGuid());
    }
    public static UserId Create(Guid value)
    {
        return new UserId(value);
    }
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    public bool Equals(UserId? other)
    {
        if (other is null) return false;
        return Value.Equals(other.Value);
    }
}