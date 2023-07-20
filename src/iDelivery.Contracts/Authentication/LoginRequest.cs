using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace iDelivery.Contracts.Authentication;

public sealed record LoginRequest(
    [EmailAddress] string Email,
    [PasswordPropertyText] string Password
);
