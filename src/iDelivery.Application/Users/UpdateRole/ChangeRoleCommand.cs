namespace iDelivery.Application.Users.UpdateRole;

public sealed record ChangeRoleCommand(
    Guid AccountId,
    Guid UserId,
    string PreviousRole,
    string NewRole,
    Guid? SupervisorId,
    string? PoBox
) : IRequest<Result<UserResponse>>;
