namespace iDelivery.Contracts.Commands;

public record UpdateCommandRequest(
    string Intitule,
    string City,
    string Quarter,
    long Longitude,
    long Latitude,
    DateTime PreferredDate,
    DateTime PreferredTime
);
