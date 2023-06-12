using iDelivery.Domain.CommandAggregate.Entities;
using iDelivery.Domain.CommandAggregate.ValueObjects;
using iDelivery.Domain.Common.ValueObjects;

namespace iDelivery.Domain.CommandAggregate;
public sealed class Command : AggregateRoot<CommandId>
{
    private readonly List <ComplaintId> _complaintIds = new();
    public IReadOnlyList <ComplaintId> ComplaintIds => _complaintIds.AsReadOnly ();
    public DeliveryStatus DeliveryStatus { get; }
    public string RefNum { get; }
    public string Intitule { get; }
    public string City { get; }
    public string Quarter { get; }
    public long Latitude { get; }
    public long Longitude { get; }
    public DateTime CreatedDate { get; }
    public DateTime PreferredDate { get; }
    public DateTime PreferredTime { get; }

    private Command(
        CommandId id,
        string refNum,
        string intitule,
        string city,
        string quarter,
        long latitude,
        long longitude,
        DeliveryStatus deliveryStatus,
        DateTime createdDate,
        DateTime preferredDate,
        DateTime preferredTime) : base(id)
        {
            RefNum = refNum;
            Intitule = intitule;
            City = city;
            Quarter = quarter;
            Latitude = latitude;
            Longitude = longitude;
            CreatedDate = createdDate;
            PreferredDate = preferredDate;
            PreferredTime = preferredTime;
            DeliveryStatus = deliveryStatus;
        }

    public static Command Create(
        string refNum,
        string intitule,
        string city,
        string quarter,
        long latitude,
        long longitude,
        DeliveryStatus deliveryStatus,
        DateTime createdDate,
        DateTime preferredDate,
        DateTime preferredTime)
        {
            return new(
                CommandId.CreateUnique(),
                refNum,
                intitule,
                city,
                quarter,
                latitude,
                longitude,
                deliveryStatus,
                createdDate,
                preferredDate,
                preferredTime
            );
        }
}
