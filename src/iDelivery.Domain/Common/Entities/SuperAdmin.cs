using iDelivery.Domain.AccountAggregate.Entities;
using iDelivery.Domain.AccountAggregate.Enums;
using iDelivery.Domain.AccountAggregate.ValueObjects;
using iDelivery.Domain.Common.ValueObjects;

namespace iDelivery.Domain.AccountAggregate;

public sealed class SuperAdmin : User
{
    private SuperAdmin(
        SuperAdminId id,
        Email email,
        Password password,
        string name,
        PhoneNumber phoneNumber,
        AccountId accountId) : base(
            id,
            email,
            password,
            name,
            phoneNumber,
            accountId)
    {
    }
    public static new SuperAdmin Create(
        string email,
        string password,
        string name,
        int phoneNumber,
        Guid accountId)
    {
        return new SuperAdmin(
            SuperAdminId.CreateUnique(),
            Email.Create(email),
            Password.Create(password),
            name,
            PhoneNumber.Create(phoneNumber),
            AccountId.Create(accountId));
    }
}