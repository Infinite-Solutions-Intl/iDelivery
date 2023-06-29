namespace iDelivery.Application.Complaints;

public sealed record ComplaintResponse(
    Guid ComplaintId,
    string? Objet,
    string? Message,
    //Guid CommandId,
    //Guid ManagerId,
    string? PictureBlob = null
);