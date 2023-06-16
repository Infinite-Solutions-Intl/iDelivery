namespace iDelivery.Domain.CourierAggregate.ValueObjects;

public sealed class CourseId : ValueObject
{
    public Guid Value { get; set; }
    private CourseId(Guid value)
    {
        Value = value;
    }
    private CourseId()
    {
    }
    public static CourseId Create(Guid value)
    {
        return new CourseId(value);
    }
    public static CourseId CreateUnique()
    {
        return new CourseId(Guid.NewGuid());
    }
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
