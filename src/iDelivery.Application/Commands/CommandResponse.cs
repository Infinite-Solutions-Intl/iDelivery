namespace iDelivery.Application.Commands;

public sealed record CommandResponse(
    Guid CommandId,
    string RefNum,
    string Intitule,
    string City,
    string Quarter,
    long Longitude,
    long Latitude,
    int Status,
    DateTime PreferredDate,
    DateTime PreferredTime
);
