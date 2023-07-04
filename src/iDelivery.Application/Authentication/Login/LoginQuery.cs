namespace iDelivery.Application.Authentication.Login;

public record LoginQuery(
    Guid AccountId,
    string Email,
    string Password) : IRequest<Result<LoginQueryResponse>>;
