namespace iDelivery.Contracts.Couriers;
public record DeleteCourierRequest(
    Guid CommandId,
    Guid CourierId
);