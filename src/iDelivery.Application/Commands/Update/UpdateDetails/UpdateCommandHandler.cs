using iDelivery.Domain.CommandAggregate.ValueObjects;

namespace iDelivery.Application.Commands.Update.UpdateDetails;
public sealed class UpdateCommandHandler : IRequestHandler<UpdateCommand, Result<CommandResponse>>
{
    private readonly ICommandRepository _commandRepository;
    private readonly IMapper _mapper;

    public UpdateCommandHandler(
        ICommandRepository commandRepository,
        IMapper mapper)
    {
        _commandRepository = commandRepository;
        _mapper = mapper;
    }

    public async Task<Result<CommandResponse>> Handle(UpdateCommand request, CancellationToken cancellationToken)
    {
        AccountId accountId = AccountId.Create(request.AccountId);
        var id = CommandId.Create(request.Id);

        var command = await _commandRepository.GetByIdAsync(
            accountId,
            id,
            cancellationToken);

        if (command is null || command.RefNum != request.RefNum)
            return Result.Fail<CommandResponse>(new CommandNorFoundError());

        command.Update(request.City, request.Quarter, request.Latitude, request.Longitude, request.PreferredDate, request.PreferredTime);
        await _commandRepository.UpdateCommandAsync(command, cancellationToken);
        return _mapper.Map<CommandResponse>(command);
    }
}
