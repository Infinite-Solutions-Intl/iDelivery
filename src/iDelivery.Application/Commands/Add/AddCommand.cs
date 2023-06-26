namespace iDelivery.Application.Commands.Add;

public sealed record AddCommand(
    string RefNum,
    string Intitule,
    string City,
    string Quarter,
    long Longitude,
    long Latitude,
    DateTime PreferredDate,
    DateTime PreferredTime
) : IRequest<Result<CommandResponse>>;
