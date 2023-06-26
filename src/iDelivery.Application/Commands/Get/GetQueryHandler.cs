namespace iDelivery.Application.Commands.Get;
public sealed class GetQueryHandler : IRequestHandler<GetQuery, Result<IReadOnlyList<CommandResponse>>>
{
    private readonly ICommandRepository _commandRepository;

    public GetQueryHandler(ICommandRepository commandRepository)
    {
        _commandRepository = commandRepository;
    }

    public async Task<Result<IReadOnlyList<CommandResponse>>> Handle(GetQuery request, CancellationToken cancellationToken)
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
