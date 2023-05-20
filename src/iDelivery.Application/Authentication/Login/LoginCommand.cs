using MediatR;

namespace iDelivery.Application.Authentication.Login;

public record LoginCommand(string Email, string Password) : IRequest<LoginCommandResponse>;
