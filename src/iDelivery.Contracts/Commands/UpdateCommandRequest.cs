namespace iDelivery.Contracts.Commands;

public record UpdateCommandRequest(
    Guid CommandId,
    string City,
    string Quarter,
    long Longitude,
    long Latitude,
    DateTime PreferredDate,
    DateTime PreferredTime
);
