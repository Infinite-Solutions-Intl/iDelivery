namespace iDelivery.Application.Commands.UpdateCommands;

public sealed class UpdateCommandHandler : IRequestHandler<UpdateCommand, Result<UpdateCommandResponse>>
{
    public Task<Result<UpdateCommandResponse>> Handle(UpdateCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}

