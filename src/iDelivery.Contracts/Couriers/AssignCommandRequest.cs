namespace iDelivery.Contracts.Couriers;
public record AddCourierRequest(
    Guid CommandId,
    Guid CourierId
);