namespace iDelivery.Contracts.Authentication;

public sealed record RegisterRequestDto(
    string Email,
    string Password,
    string Name,
    int PhoneNumber,
    int CountryIdentifier
);
