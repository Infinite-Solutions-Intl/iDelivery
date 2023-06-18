using iDelivery.Domain.AccountAggregate.Entities;
using iDelivery.Domain.AccountAggregate.ValueObjects;
using iDelivery.Domain.Common.Utilities;
using iDelivery.Domain.Common.ValueObjects;

namespace iDelivery.Domain.AccountAggregate;

public sealed class Partner : User
{
    public string PoBox {get; private set;}
    private Partner(
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

    public static Partner Create(
        string email,
        string password,
        string name,
        int phoneNumber,
        string poBox,
        Guid accountId)
    {
        return new Partner(
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