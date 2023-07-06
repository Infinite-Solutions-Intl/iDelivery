namespace iDelivery.Application.Couriers.Add;
public sealed record AssignCommand(
    Guid AccountId,
    Guid CourierId,
    Guid CommandId) : IRequest<Result<CourierResponse>>;