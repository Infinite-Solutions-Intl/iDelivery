namespace iDelivery.Application.Couriers.Add;

public sealed record AddCourir(
    Guid CommandId
) : IRequest<Result<CourierResponse>>;