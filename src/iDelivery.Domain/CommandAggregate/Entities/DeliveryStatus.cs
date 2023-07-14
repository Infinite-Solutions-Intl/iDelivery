using iDelivery.Domain.CommandAggregate.Enums;
using iDelivery.Domain.CommandAggregate.ValueObjects;

namespace iDelivery.Domain.CommandAggregate.Entities;
public sealed class DeliveryStatus : Entity<DeliveryStatusId>
{
    public Status Status { get; private set; }
    public DateTime Date { get; private set; }
    public CommandId CommandId { get; private set; }
    public string Message { get; private set; }

    private DeliveryStatus(
        DeliveryStatusId id,
        CommandId commandId,
        Status status,
        string message,
        DateTime date) : base(id)
    {
        Status = status;
        Message = message;
        Date = date;
        CommandId = commandId;
    }

    #pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    private DeliveryStatus()
    {

    }
    #pragma warning restore CS8618

    public static DeliveryStatus Create(
        CommandId commandId,
        Status status,
        DateTime date)
    {
        string message = status switch
        {
            Status.Pending => "Votre colis est en attente de préparation",
            Status.Processing => "Colis en cours de préparation",
            Status.Transit => "Vote colis est en cours de livraison",
            Status.Delivering => "Votre colis est en cours de livraison vers le client",
            Status.Delivered => "Colis livré",
            Status.Gathering => "Colis en cours de récupération",
            Status.Returning => "Colis en cours de retour vers le magasin",
            Status.Returned => "Colis retourné",
            _ => string.Empty
        };

        return new DeliveryStatus(
            DeliveryStatusId.CreateUnique(),
            commandId,
            status,
            message,
            date);
    }
}
