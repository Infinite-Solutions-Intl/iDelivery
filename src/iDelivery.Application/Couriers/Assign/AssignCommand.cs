namespace iDelivery.Application.Couriers.Assign;
public sealed record AssignCommand(
    Guid AccountId,
    Guid CourierId,
    Guid CommandId) : IRequest<Result<CourierResponse>>;