namespace iDelivery.Contracts.Complaints;
 public record AddComplaintRequest(
    string Objet,
    string Message,
    //Guid CommandId,
    //Guid ManagerId,
    string PictureBlob
 );