using iDelivery.Domain.CommandAggregate;
using iDelivery.Domain.CommandAggregate.ValueObjects;

namespace iDelivery.Application.Commands.Update.UpdateStatus;

public class UpdateDeliveryStatusCommandHandler : IRequestHandler<UpdateDeliveryStatusCommand, Result<CommandResponse>>
{
    private readonly ICommandRepository _commandRepository;
    private readonly IMapper _mapper;

    public UpdateDeliveryStatusCommandHandler(
        ICommandRepository commandRepository,
        IMapper mapper)
    {
        _commandRepository = commandRepository;
        _mapper = mapper;
    }

    public async Task<Result<CommandResponse>> Handle(UpdateDeliveryStatusCommand request, CancellationToken cancellationToken)
    {
        AccountId accountId = AccountId.Create(request.AccountId);
        CommandId commandId = CommandId.Create(request.CommandId);

        Command? command = await _commandRepository.GetByIdAsync(
            accountId,
            commandId,
            cancellationToken);

        if (command is null)
            return Result.Fail<CommandResponse>(new CommandNorFoundError());

        await _commandRepository.UpdateStatusAsync(command, request.Status, cancellationToken);

        // TODO: Publish the updated status event
        return _mapper.Map<CommandResponse>(command);
    }
}
