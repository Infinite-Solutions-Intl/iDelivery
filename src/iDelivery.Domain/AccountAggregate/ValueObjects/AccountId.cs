using System.Security.Principal;

namespace iDelivery.Domain.AccountAggregate.ValueObjects;

public sealed class AccountId : ValueObject
{
    public Guid Id { get; set; }

    private AccountId(Guid id)
    {
        Id = id;
    }

    private AccountId()
    {
        
    }
    public static AccountId CreateUnique()
    {
        return new AccountId(Guid.NewGuid());
    }
    public static AccountId Create(Guid id)
    {
        return new AccountId(id);
    }
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Id;
    }
}
