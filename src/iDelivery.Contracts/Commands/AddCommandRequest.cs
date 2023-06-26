namespace iDelivery.Contracts.Commands;

public record AddCommandRequest(
    string RefNum,
    string Intitule
    //string City,
    //string Quarter,
    //long Longitude,
    //long Latitude,
    //DateTime PreferredDate,
    //DateTime PreferredTime
);
