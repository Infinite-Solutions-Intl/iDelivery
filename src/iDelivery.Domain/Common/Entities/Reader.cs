using iDelivery.Domain.AccountAggregate.Entities;
using iDelivery.Domain.AccountAggregate.Enums;
using iDelivery.Domain.AccountAggregate.ValueObjects;
using iDelivery.Domain.Common.ValueObjects;

namespace iDelivery.Domain.AccountAggregate;

public sealed class Reader : User
{
<<<<<<< HEAD
=======
    public string PoBox {get; set;}
>>>>>>> 6ba0013 (corrections)
    protected Reader(
        ReaderId id,
        Email email,
        Password password,
        string name,
<<<<<<< HEAD
        PhoneNumber phoneNumber) : base(
=======
        PhoneNumber phoneNumber,
        string poBox) : base(
>>>>>>> 6ba0013 (corrections)
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
<<<<<<< HEAD
=======
                PoBox = poBox;
>>>>>>> 6ba0013 (corrections)
            }
    public static Reader Create(
        string email,
        string password,
        string name,
<<<<<<< HEAD
        int phoneNumber)
=======
        int phoneNumber,
        string poBox)
>>>>>>> 6ba0013 (corrections)
    {
        return new Reader(
            ReaderId.CreateUnique(),
            Email.Create(email),
            Password.Create(password),
            name,
<<<<<<< HEAD
            PhoneNumber.Create(phoneNumber));
=======
            PhoneNumber.Create(phoneNumber),
            poBox);
>>>>>>> 6ba0013 (corrections)
    }
}