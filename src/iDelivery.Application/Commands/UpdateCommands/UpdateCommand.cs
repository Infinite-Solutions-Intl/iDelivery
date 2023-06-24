namespace iDelivery.Application.Commands.UpdateCommands;

public sealed record UpdateCommand(
    string Intitule,
    string City,
    string Quarter,
    long Longitude,
    long Latitude,
    DateTime PreferredDate,
    DateTime PreferredTime
): IRequest<Result<UpdateCommandResponse>>;