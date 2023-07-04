namespace iDelivery.Application.Users.Add;

public sealed record AddUserCommandResponse(
    Guid Id,
    Guid AccountId,
    string Email,
    string Password,
    string Name,
    string PhoneNumber,
    string Role,
    string? PoBox
);
