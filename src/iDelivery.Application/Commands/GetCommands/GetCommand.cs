namespace iDelivery.Application.Commands.GetCommands;

public sealed record GetCommand(
): IRequest<Result<GetCommandResponse>>;