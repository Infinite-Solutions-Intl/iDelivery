using iDelivery.Domain.CommandAggregate.ValueObjects;

namespace iDelivery.Domain.CommandAggregate.Entities;
 public sealed class DeliveryStatus : Entity<DeliveryStatusId>
 {

    public int Status {get; private set;}
    public string FileBlod {get; private set;}
    public string FileType {get; private set;}
    public DateTime CreatedDate {get; private set;}

     public DeliveryStatus(DeliveryStatusId id,
     int status,
     string fileblod,
     string filetype,
     DateTime createddate) : base(id)
    {
        Status = status;
        FileBlod = fileblod;
        FileType = filetype;
        CreatedDate = createddate;
    }
    public static DeliveryStatus Create(
        int status,
        string fileblod,
        string filetype,
        DateTime createddate)
    {
        return new DeliveryStatus(
            DeliveryStatusId.CreateUnique(),
            status,
            fileblod,
            filetype,
            createddate);
    }
 }