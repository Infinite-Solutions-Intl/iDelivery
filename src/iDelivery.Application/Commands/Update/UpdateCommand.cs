namespace iDelivery.Application.Commands.Update;

public sealed record UpdateCommand(
    int Status
) : IRequest<Result<UpdateCommandResponse>>;