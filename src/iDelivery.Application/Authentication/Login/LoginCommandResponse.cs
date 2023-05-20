using iDelivery.Domain.AccountAggregate.Enums;

namespace iDelivery.Application.Authentication.Login;

public sealed record LoginCommandResponse(
    string token
);
