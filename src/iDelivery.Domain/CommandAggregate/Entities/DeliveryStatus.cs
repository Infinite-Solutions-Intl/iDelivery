using iDelivery.Domain.CommandAggregate.Enums;
using iDelivery.Domain.CommandAggregate.ValueObjects;

namespace iDelivery.Domain.CommandAggregate.Entities;
public sealed class DeliveryStatus : Entity<DeliveryStatusId>
{
    public Status Status { get; private set; }
    public string? FileBlob { get; private set; }
    public string? FileType { get; private set; }
    public DateTime CreatedDate { get; private set; }

    private DeliveryStatus(DeliveryStatusId id,
        Status status,
        string? fileBlob,
        string? filetype,
        DateTime createdDate) : base(id)
    {
        Status = status;
        FileBlob = fileBlob;
        FileType = filetype;
        CreatedDate = createdDate;
    }

    private DeliveryStatus()
    {

    }

    public static DeliveryStatus Create(
        Status status,
        string? fileBlob,
        string? filetype,
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
