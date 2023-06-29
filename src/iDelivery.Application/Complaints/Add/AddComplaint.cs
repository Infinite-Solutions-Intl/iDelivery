namespace iDelivery.Application.Complaints;

public sealed record AddComplaint(
    string Objet,
    string Message,
    //Guid CommandId,
    //Guid ManagerId,
    string PictureBlob
): IRequest<Result<ComplaintResponse>>;