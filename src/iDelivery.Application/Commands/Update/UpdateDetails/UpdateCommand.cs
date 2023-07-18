namespace iDelivery.Application.Commands.Update.UpdateDetails;

public sealed record UpdateCommand(
    Guid Id,
    Guid AccountId,
    string RefNum,
    string? City,
    string? Quarter,
    long? Longitude,
    long? Latitude,
    DateTime? PreferredDate,
    DateTime? PreferredTime
) : IRequest<Result<CommandResponse>>;