namespace iDelivery.Application.Commands.Get;
public sealed class GetCommandQueryHandler : IRequestHandler<GetCommandQuery, Result<IReadOnlyList<CommandResponse>>>
{
    private readonly ICommandRepository _commandRepository;

    public GetCommandQueryHandler(ICommandRepository commandRepository)
    {
        _commandRepository = commandRepository;
    }

    public async Task<Result<IReadOnlyList<CommandResponse>>> Handle(GetCommandQuery request, CancellationToken cancellationToken)
    {
        var commands = await _commandRepository.GetAllAsync(cancellationToken);
        return commands.Select(c => new CommandResponse(
            c.Id.Value,
            c.RefNum,
            c.Intitule,
            c.City,
            c.Quarter,
            c.Longitude,
            c.Latitude,
            (int)c.DeliveryStatus.Status,
            c.PreferredDate,
            c.PreferredTime
        )).ToArray();
    }
}
