namespace iDelivery.Application.Commands.GetCommands;
public sealed class GetCommandHandler : IRequestHandler<GetCommand, Result<GetCommandResponse>>
{
    public Task<Result<GetCommandResponse>> Handle(GetCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
