namespace iDelivery.Application.Couriers.Delete;
public sealed record DeleteCourier(
   Guid AccountId,
   Guid CourierId,
   Guid CommandId
) : IRequest<Result<CourierResponse>>;