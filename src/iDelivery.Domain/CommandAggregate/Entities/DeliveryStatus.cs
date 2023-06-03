using iDelivery.Domain.CommandAggregate.ValueObjects;

namespace iDelivery.Domain.CommandAggregate.Entities;
 public sealed class DeliveryStatus : Entity<DeliveryStatusId>
 {

    public int Status {get; private set;}
    public string FileBlob {get; private set;}
    public string FileType {get; private set;}
    public DateTime CreatedDate {get; private set;}

     public DeliveryStatus(DeliveryStatusId id,
     int status,
     string fileblob,
     string filetype,
     DateTime createddate) : base(id)
    {
        Status = status;
        FileBlob = fileblob;
        FileType = filetype;
        CreatedDate = createddate;
    }
    public static DeliveryStatus Create(
        int status,
        string fileblob,
        string filetype,
        DateTime createddate)
    {
        return new DeliveryStatus(
            DeliveryStatusId.CreateUnique(),
            status,
            fileblob,
            filetype,
            createddate);
    }
 }