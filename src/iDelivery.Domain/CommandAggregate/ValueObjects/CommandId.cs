namespace iDelivery.Domain.CommandAggregate.ValueObjects;
public sealed class CommandId : ValueObject
{
    public Guid Id { get; }
    private CommandId(Guid id)
    {
        Id = id;
    }
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Id;
    }
    public static CommandId CreateUnique()
    {
        return new(Guid.NewGuid());
    }
    public static CommandId Create(Guid id)
    {
        return new(id);
    }
}