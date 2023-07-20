using iDelivery.Domain.CommandAggregate.ValueObjects;
using iDelivery.Domain.CourierAggregate;
using iDelivery.Domain.CourierAggregate.ValueObjects;

namespace iDelivery.Application.Couriers.Assign;
public class AssignCommandHandler : IRequestHandler<AssignCommand, Result<CourierResponse>>
{
    private readonly ICourierRepository _courierRepository;
    private readonly IMapper _mapper;
    public AssignCommandHandler(
        ICourierRepository courierRepository,
        IMapper mapper)
    {
        _courierRepository = courierRepository;
        _mapper = mapper;
    }

    public async Task<Result<CourierResponse>> Handle(AssignCommand request, CancellationToken cancellationToken)
    {
        AccountId accountId = AccountId.Create(request.AccountId);
        CourierId courierId = CourierId.Create(request.CourierId);
        Courier? courier = await _courierRepository.GetByIdAsync(accountId, courierId, cancellationToken);
        if (courier is null)
            return Result.Fail<CourierResponse>(new BaseError(""));

        CommandId commandId = CommandId.Create(request.CommandId);
        bool success = await _courierRepository.AssignAsync(courier, commandId, cancellationToken);

        if (!success)
            return Result.Fail<CourierResponse>(new BaseError(""));

        return _mapper.Map<CourierResponse>(courier);
    }
}
