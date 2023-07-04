namespace iDelivery.Contracts.Users;

public sealed record UserDto(
    string Email,
    string Password,
    string Name,
    int PhoneNumber,
    int CountryIdentifier,
    string Role
);
