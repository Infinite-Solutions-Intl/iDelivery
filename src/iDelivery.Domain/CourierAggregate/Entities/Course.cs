using iDelivery.Domain.CommandAggregate.ValueObjects;
using iDelivery.Domain.CourierAggregate.ValueObjects;

namespace iDelivery.Domain.CourierAggregate.Entities;

public sealed class Course : AggregateRoot<CourseId>
{
    private readonly List<CommandId> _commandIds = new();
    public IReadOnlyList<CommandId> CommandIds => _commandIds.AsReadOnly();
    private  Course(CourseId courseId) : base(courseId)
    {

    }

    private Course()
    {
    }

    public static Course Create()
    {
        return new Course(CourseId.CreateUnique());
    }
}
