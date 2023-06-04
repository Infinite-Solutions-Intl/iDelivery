using iDelivery.Domain.CommandAggregate.Entities;
using iDelivery.Domain.CommandAggregate.ValueObjects;
using iDelivery.Domain.Common.ValueObjects;

namespace iDelivery.Domain.CommandAggregate;
public sealed class Command : AggregateRoot<CommandId>
{
    private readonly List <ComplaintId> _complaintIds = new();
    public IReadOnlyList <ComplaintId> ComplaintIds => _complaintIds.AsReadOnly ();
    public string RefNum {get; private set;}
    public string Intitule {get; private set;}
    public string City {get; private set;}
    public string Quarter {get; private set;}
    public long Latitude {get; private set;}
    public long Longitude {get; private set;}
    public DateTime CreatedDate {get; private set;}
    public DateTime PreferredDate {get; private set;}
    public DateTime PreferredTime {get; private set;}

    private Command(
        CommandId id,
        string refNum,
        string intitule,
        string city,
        string quarter,
        long latitude,
        long longitude,
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
            this.CreatedDate = createdDate;
            PreferredDate = preferredDate;
            PreferredTime = preferredTime;
        }
    private static Command Create(
        string refNum,
        string intitule,
        string city,
        string quarter,
        long latitude,
        long longitude,
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
                createdDate,
                preferredDate,
                preferredTime
            );
        }
}