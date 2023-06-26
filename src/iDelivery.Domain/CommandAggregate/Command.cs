using iDelivery.Domain.AccountAggregate;
using iDelivery.Domain.CommandAggregate.Entities;
using iDelivery.Domain.CommandAggregate.Enums;
using iDelivery.Domain.CommandAggregate.ValueObjects;

namespace iDelivery.Domain.CommandAggregate;
public sealed class Command : AggregateRoot<CommandId>
{
    private readonly List <Complaint> _complaints = new();
    public IReadOnlyList <Complaint> Complaints => _complaints.AsReadOnly ();
    public DeliveryStatus DeliveryStatus { get; private set; }
    public string RefNum { get; private set; }
    public string Intitule { get; private set; }
    public string City { get; private set; }
    public string Quarter { get; private set; }
    public long Latitude { get; private set; }
    public long Longitude { get; private set; }
    public DateTime CreatedDate { get; private set; }
    public DateTime PreferredDate { get; private set; }
    public DateTime PreferredTime { get; private set; }

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

    #pragma warning disable CS8618
    private Command()
    {

    }
    #pragma warning restore CS8618
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

    public void Update(Command command)
    {
        RefNum = command.RefNum;
        Intitule = command.Intitule;
        City = command.City;
        Quarter = command.Quarter;
        Latitude = command.Latitude;
        Longitude = command.Longitude;
        CreatedDate = command.CreatedDate;
        PreferredDate = command.PreferredDate;
        PreferredTime = command.PreferredTime;
        DeliveryStatus = command.DeliveryStatus;
    }

    public void UpdateStatus(Status status)
    {
        DeliveryStatus = DeliveryStatus.Create(
            status,
            DeliveryStatus.FileBlob,
            DeliveryStatus.FileType,
            DateTime.Now);
    }
}
