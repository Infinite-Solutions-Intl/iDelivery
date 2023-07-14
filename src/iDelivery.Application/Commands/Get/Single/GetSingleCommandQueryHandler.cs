using iDelivery.Domain.CommandAggregate;
using iDelivery.Domain.CommandAggregate.ValueObjects;

namespace iDelivery.Application.Commands.Get.Single;

public class GetSingleCommandQueryHandler : IRequestHandler<GetSingleCommandQuery, Result<CommandResponse>>
{
    private readonly ICommandRepository _commandRepository;

    public GetSingleCommandQueryHandler(ICommandRepository commandRepository)
    {
        _commandRepository = commandRepository;
    }

    public async Task<Result<CommandResponse>> Handle(GetSingleCommandQuery request, CancellationToken cancellationToken)
    {
        CommandId commandId = CommandId.Create(request.CommandId);
        Command? command = await _commandRepository.GetByIdAsync(commandId, cancellationToken);
        if(command is null)
            return Result.Fail("Command not found!");

        return new CommandResponse(
            command.Id.Value,
            command.RefNum,
            command.Intitule,
            command.City,
            command.Quarter,
            command.Longitude,
            command.Latitude,
            command.DeliveryStatuses.Select(ds => new DeliveryStatusResponse(
                ds.Id.Value,
                ds.CommandId.Value,
                (int) ds.Status,
                ds.Date,
                ds.Message
            )).ToArray(),
            command.PreferredDate,
            command.PreferredTime);
    }
}
