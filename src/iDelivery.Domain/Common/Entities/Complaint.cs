using iDelivery.Domain.AccountAggregate.Entities;
using iDelivery.Domain.AccountAggregate.Enums;
using iDelivery.Domain.AccountAggregate.ValueObjects;
using iDelivery.Domain.Common.ValueObjects;
namespace iDelivery.Domain.AccountAggregate;

public sealed class Complaint : User
{
   
    public Email Email { get; set; }
    public Password Password { get; set; }
    public string Name { get; set; }
    public PhoneNumber PhoneNumber { get; set; }
    public AccountId AccountId{get; set;}
    public string Objet {get; set;}
    public string Message {get; set;}
    public int Statut {get; set;}
    public string PictureBlob {get; set;}

    protected Complaint(ComplaintId id, Email email, Password password, string name, PhoneNumber phoneNumber, string objet, string message, int statut, string pictureBlod) : base(id)
    {
        Email = email;
        Password = password;
        Name = name;
        PhoneNumber = phoneNumber;
        Objet = objet;
        Message = message;
        Statut = statut;
        PictureBlob = pictureBlod;
    }
    public static Complaint Create(
        string email,
        string password,
        string name,
        int phoneNumber,
        string objet,
        string message,
        int statut,
        string pictureBlod)
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
            pictureBlod);
    }
}