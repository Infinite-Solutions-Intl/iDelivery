namespace iDelivery.Domain.AccountAggregate.ValueObjects;

public sealed class AccountId : ValueObject
{
    public Guid Value { get; private set; }

    private AccountId(Guid value)
    {
        Value = value;
    }

    private AccountId()
    {
        
    }
    public static AccountId CreateUnique()
    {
        return new AccountId(Guid.NewGuid());
    }
    public static AccountId Create(Guid value)
    {
        return new AccountId(value);
    }
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
