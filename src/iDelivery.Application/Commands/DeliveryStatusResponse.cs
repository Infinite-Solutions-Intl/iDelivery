namespace iDelivery.Application.Commands;

public sealed record DeliveryStatusResponse(
    Guid Id,
    Guid CommandId,
    int Status,
    DateTime Date,
    string Message
);
