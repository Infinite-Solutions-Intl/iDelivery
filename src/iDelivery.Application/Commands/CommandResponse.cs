namespace iDelivery.Application.Commands;

public sealed record CommandResponse(
    Guid Id,
    string RefNum,
    string Intitule,
    string City,
    string Quarter,
    long Longitude,
    long Latitude,
    DeliveryStatusResponse[] Statuses,
    DateTime PreferredDate,
    DateTime PreferredTime
);
