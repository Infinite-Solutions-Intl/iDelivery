namespace iDelivery.Application.Users.Delete;

public sealed record DeleteUserCommandResponse(
    bool Success,
    int Records
);
