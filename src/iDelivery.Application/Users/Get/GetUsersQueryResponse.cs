namespace iDelivery.Application.Users.Get;

public sealed record GetUsersQueryResponse(
    string Email,
    Guid AccountId,
    string Password,
    string Name,
    string PhoneNumber,
    string Role,
    Guid? SupervisorId,
    string? PoBox
);