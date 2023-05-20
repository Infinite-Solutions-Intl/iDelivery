using FluentResults;

namespace iDelivery.Application.Authentication.Login;

public record LoginQuery(string Email, string Password) : IRequest<Result<LoginQueryResponse>>;
