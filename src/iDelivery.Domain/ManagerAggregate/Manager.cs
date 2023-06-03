using iDelivery.Domain.AccountAggregate.Entities;
using iDelivery.Domain.AccountAggregate.Enums;
using iDelivery.Domain.AccountAggregate.ValueObjects;
<<<<<<< HEAD
=======
using iDelivery.Domain.Common.ValueObjects;
>>>>>>> 6ba0013 (corrections)
using iDelivery.Domain.ManagerAggregate.ValueObjects;

namespace iDelivery.Domain.AccountAggregate;

public sealed class Manager : User
{
<<<<<<< HEAD
=======
    private readonly List <ComplaintId> _complaintIds = new();
    public IReadOnlyList <ComplaintId> ComplaintIds => _complaintIds.AsReadOnly ();
>>>>>>> 6ba0013 (corrections)
    private Manager(
        ManagerId id,
        Email email,
        Password password,
        string name,
        PhoneNumber phoneNumber) : base(
            id,
            email,
            password,
            name,
            phoneNumber)
            {
               Email = email;
            Password = password;
            Name = name;
            PhoneNumber = phoneNumber; 
            }
    public static Manager Create(
        string email,
        string password,
        string name,
        int phoneNumber)
    {
        return new Manager(
            ManagerId.CreateUnique(),
            Email.Create(email),
            Password.Create(password),
            name,
            PhoneNumber.Create(phoneNumber));
    }
}