using iDelivery.Domain.AccountAggregate.Entities;
using iDelivery.Domain.AccountAggregate.Enums;
using iDelivery.Domain.AccountAggregate.ValueObjects;
using iDelivery.Domain.Common.ValueObjects;

namespace iDelivery.Domain.AccountAggregate;

public sealed class Reader : User
{
    public string PoBox {get; set;}
    private Reader(
        ReaderId id,
        Email email,
        Password password,
        string name,
        PhoneNumber phoneNumber,
        AccountId accountId,
        string poBox) : base(
            id,
            email,
            password,
            name,
            phoneNumber,
            accountId)
    {
        PoBox = poBox;   
    }


    public static Reader Create(
        string email,
        string password,
        string name,
        int phoneNumber,
        string poBox,
        Guid accountId)
    {
        return new Reader(
            ReaderId.CreateUnique(),
            Email.Create(email),
            Password.Create(password),
            name,
            PhoneNumber.Create(phoneNumber),
            AccountId.Create(accountId),
            poBox);
    }
}