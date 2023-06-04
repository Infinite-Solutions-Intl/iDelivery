using iDelivery.Domain.AccountAggregate.Entities;
using iDelivery.Domain.AccountAggregate.Enums;
using iDelivery.Domain.AccountAggregate.ValueObjects;
using iDelivery.Domain.Common.Utilities;
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
        string role,
        AccountId accountId,
        string poBox) : base(
            id,
            email,
            password,
            name,
            phoneNumber,
            role,
            accountId)
    {
        PoBox = poBox;   
    }


    public static new Reader Create(
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
            Roles.Reader,
            AccountId.Create(accountId),
            poBox);
    }
}