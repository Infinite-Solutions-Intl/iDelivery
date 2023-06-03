using iDelivery.Domain.AccountAggregate.Entities;
using iDelivery.Domain.AccountAggregate.Enums;
using iDelivery.Domain.AccountAggregate.ValueObjects;
<<<<<<< HEAD
using iDelivery.Domain.Common.ValueObjects;
=======
using iDelivery.Domain.CommandAggregate.ValueObjects;
using iDelivery.Domain.Common.ValueObjects;
using iDelivery.Domain.ManagerAggregate.ValueObjects;

>>>>>>> 6ba0013 (corrections)
namespace iDelivery.Domain.AccountAggregate;

public sealed class Complaint : User
{
   
    public Email Email { get; set; }
    public Password Password { get; set; }
    public string Name { get; set; }
    public PhoneNumber PhoneNumber { get; set; }
<<<<<<< HEAD
    public AccountId AccountId{get; set;}
=======
>>>>>>> 6ba0013 (corrections)
    public string Objet {get; set;}
    public string Message {get; set;}
    public int Statut {get; set;}
    public string PictureBlob {get; set;}
<<<<<<< HEAD

    protected Complaint(ComplaintId id, Email email, Password password, string name, PhoneNumber phoneNumber, string objet, string message, int statut, string pictureBlod) : base(id)
=======
    public CommandId CommandId {get; set;}
    public ManagerId ManagerId {get; set;}

    protected Complaint(ComplaintId id, Email email, Password password, string name, PhoneNumber phoneNumber, string objet, string message, int statut, string pictureBlod, CommandId commandId, ManagerId managerId) : base(id)
>>>>>>> 6ba0013 (corrections)
    {
        Email = email;
        Password = password;
        Name = name;
        PhoneNumber = phoneNumber;
        Objet = objet;
        Message = message;
        Statut = statut;
        PictureBlob = pictureBlod;
<<<<<<< HEAD
=======
        CommandId = commandId;
        ManagerId = managerId;
>>>>>>> 6ba0013 (corrections)
    }
    public static Complaint Create(
        string email,
        string password,
        string name,
        int phoneNumber,
        string objet,
        string message,
        int statut,
<<<<<<< HEAD
        string pictureBlod)
=======
        string pictureBlod,
        Guid commandId,
        Guid managerId)
>>>>>>> 6ba0013 (corrections)
    {
        return new Complaint(
            ComplaintId.CreateUnique(),
            Email.Create(email),
            Password.Create(password),
            name,
            PhoneNumber.Create(phoneNumber),
            objet,
            message,
            statut,
<<<<<<< HEAD
            pictureBlod);
=======
            pictureBlod,
            CommandId.Create(commandId),
            ManagerId.Create(managerId));
>>>>>>> 6ba0013 (corrections)
    }
}