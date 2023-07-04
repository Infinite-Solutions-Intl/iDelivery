namespace iDelivery.Application.Couriers.Delete;
 public sealed record DeleteCourier(
    Guid CourierId,
    Guid CommandId
 ) : IRequest<Result<CourierResponse>>;