namespace iDelivery.Application.Users;

public sealed record UserResponse(
    Guid Id,
    Guid AccountId,
    string Email,
    string Password,
    string Name,
    string PhoneNumber,
    string Role,
    Guid? SupervisorId,
    string? PoBox
);