using iDelivery.Application.Commands.Update.Commands;
using iDelivery.Domain.CommandAggregate;
using iDelivery.Domain.CommandAggregate.ValueObjects;

namespace iDelivery.Application.Commands.Update.Handlers;

public class UpdateDeliveryStatusCommmandHandler : IRequestHandler<UpdateDeliveryStatusCommand, Result<CommandResponse>>
{
    private readonly ICommandRepository _commandRepository;

    public UpdateDeliveryStatusCommmandHandler(ICommandRepository commandRepository)
    {
        _commandRepository = commandRepository;
    }

    public async Task<Result<CommandResponse>> Handle(UpdateDeliveryStatusCommand request, CancellationToken cancellationToken)
    {
        Command? command = await _commandRepository.GetByIdAsync(
            CommandId.Create(request.CommandId),
            cancellationToken);
        if (command is null)
            return Result.Fail(new BaseError("The command does not exist"));

        await _commandRepository.UpdateStatusAsync(command, request.Status, cancellationToken);

        // TODO: Publier le statut d'une commande a ete modifie
        return new CommandResponse(
            command.Id.Value,
            command.RefNum,
            command.Intitule,
            command.City,
            command.Quarter,
            command.Longitude,
            command.Latitude,
            (int)command.DeliveryStatus.Status,
            command.PreferredDate,
            command.PreferredTime);
    }
}
