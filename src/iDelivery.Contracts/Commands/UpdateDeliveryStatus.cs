namespace iDelivery.Contracts.Commands;

public record UpdateDeliveryStatus(
    Guid CommandId,
    int status);
