using iDelivery.Domain.AccountAggregate.Entities;
using iDelivery.Domain.AccountAggregate.Enums;
using iDelivery.Domain.AccountAggregate.ValueObjects;
using iDelivery.Domain.Common.ValueObjects;

namespace iDelivery.Domain.AccountAggregate;

public sealed class Reader : User
{
    protected Reader(
        ReaderId id,
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
    public static Reader Create(
        string email,
        string password,
        string name,
        int phoneNumber)
    {
        return new Reader(
            ReaderId.CreateUnique(),
            Email.Create(email),
            Password.Create(password),
            name,
            PhoneNumber.Create(phoneNumber));
    }
}