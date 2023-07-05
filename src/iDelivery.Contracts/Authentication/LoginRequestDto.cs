namespace iDelivery.Contracts.Authentication;

public sealed record LoginRequestDto(
    string Email,
    string Password
);
