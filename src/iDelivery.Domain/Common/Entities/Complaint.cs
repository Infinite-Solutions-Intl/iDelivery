using iDelivery.Domain.AccountAggregate.Entities;
using iDelivery.Domain.AccountAggregate.Enums;
using iDelivery.Domain.AccountAggregate.ValueObjects;
using iDelivery.Domain.CommandAggregate.ValueObjects;
using iDelivery.Domain.Common.Enums;
using iDelivery.Domain.Common.ValueObjects;
using iDelivery.Domain.ManagerAggregate.ValueObjects;
namespace iDelivery.Domain.AccountAggregate;

public sealed class Complaint
{
    public string Object {get; set;}
    public string Message {get; set;}
    public ComplaintStatus Status {get; set;}
    public string? PictureBlob {get; set;}
    public CommandId CommandId {get; set;}
    public ManagerId ManagerId {get; set;}

    private Complaint(
        string objet,
        string message,
        CommandId commandId,
        ManagerId managerId,
        string? pictureBlob = null)
    {
        CommandId = commandId;
        ManagerId = managerId;
        Object = objet;
        Message = message;
        PictureBlob = pictureBlob;
    }

    public static Complaint Create(
        string objet,
        string message,
        CommandId commandId,
        ManagerId managerId,
        string? pictureBlob = null)
    {
        return new Complaint(
            objet,
            message,
            commandId,
            managerId,
            pictureBlob = null);
    }
}