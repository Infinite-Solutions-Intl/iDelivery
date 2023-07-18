namespace iDelivery.Application.Couriers;
public sealed record CourierResponse(
    Guid Id,
    Guid SupervisorId,
    Guid[] Deliveries,
    Guid[] CommandIds
);
