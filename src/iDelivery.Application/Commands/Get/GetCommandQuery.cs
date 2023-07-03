namespace iDelivery.Application.Commands.Get;

public sealed record GetCommandQuery() : IRequest<Result<IReadOnlyList<CommandResponse>>>;