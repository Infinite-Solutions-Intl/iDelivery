using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace iDelivery.Contracts.Authentication;

public sealed record RegisterRequest(
    [EmailAddress] string Email,
    [PasswordPropertyText] string Password,
    string Name,
    int PhoneNumber,
    int CountryIdentifier
);
