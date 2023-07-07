namespace iDelivery.Application.Users.Add;

public sealed record AddUserCommand(
    string Email,
    Guid AccountId,
    string Password,
    string Name,
    int PhoneNumber,
    int CountryIdentifier,
    string Role,
    Guid? SupervisorId,
    string? PoBox
) : IRequest<Result<UserResponse>>;
