using iDelivery.Domain.AccountAggregate;
using iDelivery.Domain.AccountAggregate.ValueObjects;
using iDelivery.Domain.CommandAggregate.Entities;
using iDelivery.Domain.CommandAggregate.Enums;
using iDelivery.Domain.CommandAggregate.Events;
using iDelivery.Domain.CommandAggregate.ValueObjects;

namespace iDelivery.Domain.CommandAggregate;
public sealed class Command : AggregateRoot<CommandId>
{
    private readonly List <Complaint> _complaints = new();
    private readonly List <DeliveryStatus> _deliveryStatuses = new();

    public AccountId AccountId { get; private set; }
    public Account Account { get; private set; } = null!;
    public IReadOnlyList <Complaint> Complaints => _complaints.AsReadOnly();
    public IReadOnlyList<DeliveryStatus> DeliveryStatuses => _deliveryStatuses.AsReadOnly();
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
        AccountId accountId,
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
        CreatedDate = createdDate;
        PreferredDate = preferredDate;
        PreferredTime = preferredTime;
        AccountId = accountId;
    }

    #pragma warning disable CS8618
    private Command()
    {

    }
    #pragma warning restore CS8618
    public static Command Create(
        AccountId accountId,
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
        Command command = new(
            CommandId.CreateUnique(),
            accountId,
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
        
        DeliveryStatus deliveryStatus = DeliveryStatus.Create(
            command.Id,
            Status.Pending,
            createdDate
        );
        command._deliveryStatuses.Add(deliveryStatus);
        command.RaiseDomainEvent(new CommandCreated(command.Id, createdDate));
        return command;
    }

    public void Update(
        string? city,
        string? quarter,
        long? latitude,
        long? longitude,
        DateTime? preferredDate,
        DateTime? preferredTime)
    {
        City = city ?? City;
        Quarter = quarter ?? Quarter;
        Latitude = latitude ?? Latitude;
        Longitude = longitude ?? Longitude;
        PreferredDate = preferredDate ?? PreferredDate;
        PreferredTime = preferredTime ?? PreferredTime;
    }

    public void UpdateStatus(Status status)
    {
        DeliveryStatus deliveryStatus = DeliveryStatus.Create(
            Id,
            status,
            DateTime.Now);
        _deliveryStatuses.Add(deliveryStatus);

        RaiseDomainEvent(new CommandStatusUpdated(deliveryStatus));
    }
}
