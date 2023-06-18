using iDelivery.Domain.CommandAggregate.ValueObjects;

namespace iDelivery.Domain.CommandAggregate.Entities;
public sealed class DeliveryStatus : Entity<DeliveryStatusId>
{
    public int Status { get; private set; }
    public string FileBlob { get; private set; }
    public string FileType { get; private set; }
    public DateTime CreatedDate { get; private set; }

    private DeliveryStatus(DeliveryStatusId id,
        int status,
        string fileBlob,
        string filetype,
        DateTime createdDate) : base(id)
    {
        Status = status;
        FileBlob = fileBlob;
        FileType = filetype;
        CreatedDate = createdDate;
    }

    #pragma warning disable CS8618
    private DeliveryStatus()
    {

    }
    #pragma warning restore CS8618

    public static DeliveryStatus Create(
        int status,
        string fileBlob,
        string filetype,
        DateTime createdDate)
    {
        return new DeliveryStatus(
            DeliveryStatusId.CreateUnique(),
            status,
            fileBlob,
            filetype,
            createdDate);
    }
 }
