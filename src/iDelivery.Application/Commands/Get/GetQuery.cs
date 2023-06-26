namespace iDelivery.Application.Commands.Get;

public sealed record GetQuery(
) : IRequest<Result<IReadOnlyList<CommandResponse>>>;