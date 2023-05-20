using iDelivery.Domain.CommandAggregate.Entities;
using iDelivery.Domain.CommandAggregate.ValueObjects;

namespace iDelivery.Domain.CommandAggregate;
public sealed class Command : AggregateRoot<CommandId>
{
    public string RefNum {get; private set;}
    public string Intitule {get; private set;}
    public string City {get; private set;}
    public string Quater {get; private set;}
    public long Latitude {get; private set;}
    public long Longitude {get; private set;}
    public DateTime CreatedDate {get; private set;}
    public DateTime PreferedDate {get; private set;}
    public DateTime PreferedTime {get; private set;}

    private Command(
        CommandId id,
        string refNum,
        string intitule,
        string city,
        string quater,
        long latitude,
        long longitude,
        DateTime createdDate,
        DateTime preferedDate,
        DateTime preferedTime) : base(id)
        {
            RefNum = refNum;
            Intitule = intitule;
            City = city;
            Quater = quater;
            Latitude = latitude;
            Longitude = longitude;
            this.CreatedDate = createdDate;
            PreferedDate = preferedDate;
            PreferedTime = preferedTime;
        }
    private static Command Create(
        string refNum,
        string intitule,
        string city,
        string quater,
        long latitude,
        long longitude,
        DateTime createdDate,
        DateTime preferedDate,
        DateTime preferedTime)
        {
            return new(
                CommandId.CreateUnique(),
                refNum,
                intitule,
                city,
                quater,
                latitude,
                longitude,
                createdDate,
                preferedDate,
                preferedTime
            );
        }
}