namespace iDelivery.Application.Users.Delete;

public sealed record DeleteUserCommand(
    Guid AccountId,
    Guid UserId
) : IRequest<Result<DeleteUserCommandResponse>>;
