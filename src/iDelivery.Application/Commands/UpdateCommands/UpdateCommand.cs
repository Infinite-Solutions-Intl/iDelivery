namespace iDelivery.Application.Commands.UpdateCommands;

public sealed record UpdateCommand(
    int status
): IRequest<Result<UpdateCommandResponse>>;