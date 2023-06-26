using iDelivery.Application.Commands.Update.Commands;
using iDelivery.Domain.CommandAggregate.ValueObjects;

namespace iDelivery.Application.Commands.Update.Handlers;
public sealed class UpdateCommandHandler : IRequestHandler<UpdateCommand, Result<CommandResponse>>
{
    private readonly ICommandRepository _commandRepository;

    public UpdateCommandHandler(ICommandRepository commandRepository)
    {
        _commandRepository = commandRepository;
    }

    public async Task<Result<CommandResponse>> Handle(UpdateCommand request, CancellationToken cancellationToken)
    {
        var id = CommandId.Create(request.Id);
        var command = await _commandRepository.GetByIdAsync(id, cancellationToken);
        if (command is null)
            return Result.Fail(new BaseError("The command does not exist"));
        if(command.RefNum != request.RefNum)
            return Result.Fail(new BaseError("The command does not exist"));

        command.Update(request.City, request.Quarter, request.Latitude, request.Longitude, request.PreferredDate, request.PreferredTime);
        await _commandRepository.UpdateCommandAsync(command, cancellationToken);
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
