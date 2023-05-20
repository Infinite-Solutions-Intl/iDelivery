using MediatR;

namespace iDelivery.Application.Authentication.Register;

public sealed record RegisterCommand(
    string Email,
    string Password,
    string Name,
    int PhoneNumber,
    int CountryIdentifier) : IRequest<RegisterCommandResponse>;
