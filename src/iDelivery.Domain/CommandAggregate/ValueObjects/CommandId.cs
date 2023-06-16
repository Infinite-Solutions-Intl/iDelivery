namespace iDelivery.Domain.CommandAggregate.ValueObjects;
public sealed class CommandId : ValueObject
{
    public Guid Value { get; private set; }
    private CommandId(Guid value)
    {
        Value = value;
    }
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
    public static CommandId CreateUnique()
    {
        return new(Guid.NewGuid());
    }
    public static CommandId Create(Guid value)
    {
        return new(value);
    }
}
