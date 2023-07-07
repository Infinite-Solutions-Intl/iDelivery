using iDelivery.Domain.AccountAggregate.Entities;
using iDelivery.Domain.AccountAggregate.ValueObjects;
using iDelivery.Domain.Common.Utilities;
using iDelivery.Domain.Common.ValueObjects;

namespace iDelivery.Domain.AccountAggregate;

public sealed class Partner : User
{
    public string PoBox {get; private set;}
    private Partner(
        PartnerId id,
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

    public static new Partner Create(
        Email email,
        Password password,
        string name,
        PhoneNumber phoneNumber,
        string poBox,
        AccountId accountId)
    {
        return new Partner(
            PartnerId.CreateUnique(),
            email,
            password,
            name,
            phoneNumber,
            Roles.Partner,
            accountId,
            poBox);
    }

    internal static Partner Restore(
        PartnerId partnerId,
        Email email,
        Password password,
        string name,
        PhoneNumber phoneNumber,
        string poBox,
        AccountId accountId)
    {
        return new Partner(
            partnerId,
            email,
            password,
            name,
            phoneNumber,
            Roles.Partner,
            accountId,
            poBox);
    }
}
