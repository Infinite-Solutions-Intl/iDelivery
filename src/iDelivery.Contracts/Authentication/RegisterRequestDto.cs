using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace iDelivery.Contracts.Authentication;

public sealed record RegisterRequestDto(
    [EmailAddress] string Email,
    [PasswordPropertyText] string Password,
    string Name,
    int PhoneNumber,
    int CountryIdentifier
);
