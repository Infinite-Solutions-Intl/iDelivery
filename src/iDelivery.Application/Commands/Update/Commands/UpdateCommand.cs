namespace iDelivery.Application.Commands.Update.Commands;

public sealed record UpdateCommand(
    Guid Id,
    string RefNum,
    string? City,
    string? Quarter,
    long? Longitude,
    long? Latitude,
    DateTime? PreferredDate,
    DateTime? PreferredTime
) : IRequest<Result<CommandResponse>>;