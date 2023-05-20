namespace iDelivery.Contracts.Authentication;

public sealed record LoginREquestDto(
    string Email,
    string Password
);
