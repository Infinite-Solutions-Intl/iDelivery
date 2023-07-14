namespace iDelivery.Domain.Common.ValueObjects;

public class EventId : ValueObject
{
    public Guid Id { get; set; }
    private EventId(Guid id)
    {
        Id = id;
    }

    public static EventId Create(Guid id)
    {
        return new EventId(id);
    }

    public static EventId CreateUnique()
    {
        return new EventId(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Id;
    }
}
