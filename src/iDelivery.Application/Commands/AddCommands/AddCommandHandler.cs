namespace iDelivery.Application.Commands.AddCommands;

public sealed class AddCommandHandler : IRequestHandler<AddCommand, Result<AddCommandResponse>>
{
    public Task<Result<AddCommandResponse>> Handle(AddCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
