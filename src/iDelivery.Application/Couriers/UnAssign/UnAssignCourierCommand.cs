namespace iDelivery.Application.Couriers.UnAssign;
public sealed record UnAssignCourierCommand(
   Guid AccountId,
   Guid CourierId,
   Guid CommandId
) : IRequest<Result<CourierResponse>>;