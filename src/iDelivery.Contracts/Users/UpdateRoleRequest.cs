namespace iDelivery.Contracts.Users;

public sealed record UpdateRoleRequest(
    string PreviousRole,
    string NewRole,
    Guid? SupervisorId,
    string? PoBox
);
