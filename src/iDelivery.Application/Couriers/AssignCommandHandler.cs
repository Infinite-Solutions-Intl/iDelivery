using iDelivery.Domain.CommandAggregate.ValueObjects;
using iDelivery.Domain.CourierAggregate;
using iDelivery.Domain.CourierAggregate.ValueObjects;

namespace iDelivery.Application.Couriers.Add;
public class AssignCommandHandler : IRequestHandler<AssignCommand, Result<CourierResponse>>
{
    private readonly ICourierRepository _courierRepository;
    public AssignCommandHandler(ICourierRepository courierRepository)
    {
        _courierRepository = courierRepository;
    }

    public async Task<Result<CourierResponse>> Handle(AssignCommand request, CancellationToken cancellationToken)
    {
        AccountId accountId = AccountId.Create(request.AccountId);
        CourierId courierId = CourierId.Create(request.CourierId);
        Courier? courier = await _courierRepository.GetByIdAsync(courierId, cancellationToken);
        if(courier is null)
            return Result.Fail(new BaseError(""));

        if(courier.AccountId != accountId)
            return Result.Fail(new BaseError(""));

        CommandId commandId = CommandId.Create(request.CommandId);
        bool success = await _courierRepository.AssignAsync(courier, commandId, cancellationToken);

        if(!success)
            return Result.Fail(new BaseError(""));

        return new CourierResponse(commandId.Value, courierId.Value);
    }
}
