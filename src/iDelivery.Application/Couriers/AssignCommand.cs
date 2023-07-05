namespace iDelivery.Application.Couriers.Add;
public sealed record AssignCommand(
    Guid CourierId,
    Guid CommandId
) : IRequest<Result<CourierResponse>>;