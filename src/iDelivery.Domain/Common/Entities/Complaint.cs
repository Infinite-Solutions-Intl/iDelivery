using iDelivery.Domain.CommandAggregate.ValueObjects;
using iDelivery.Domain.Common.Enums;
using iDelivery.Domain.Common.ValueObjects;
using iDelivery.Domain.ManagerAggregate.ValueObjects;

namespace iDelivery.Domain.AccountAggregate;
public sealed class Complaint : Entity<ComplaintId>
{
    public string Object {get; private set;}
    public string Message {get; private set;}
    public ComplaintStatus Status {get; private set;}
    public string? PictureBlob {get; private set;}
    public CommandId CommandId {get; private set;}
    public ManagerId ManagerId {get; private set;}

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
    #pragma warning disable CS8618
    private Complaint()
    {

    }
    #pragma warning restore CS8618
    public static Complaint Create(
        string objet,
        string message,
        CommandId commandId,
        ManagerId managerId,
        string? pictureBlob)
    {
        return new Complaint(
            objet,
            message,
            commandId,
            managerId,
            pictureBlob);
    }
}