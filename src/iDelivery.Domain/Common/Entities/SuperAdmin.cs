using iDelivery.Domain.AccountAggregate.Entities;
using iDelivery.Domain.AccountAggregate.Enums;
using iDelivery.Domain.AccountAggregate.ValueObjects;
using iDelivery.Domain.Common.Utilities;
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
        string role,
        AccountId accountId) : base(
            id,
            email,
            password,
            name,
            phoneNumber,
            role,
            accountId)
    {
    }

    public static new SuperAdmin Create(
        string email,
        string password,
        string name,
        int phoneNumber,
        string role,
        Guid accountId)
    {
        return new SuperAdmin(
            SuperAdminId.CreateUnique(),
            Email.Create(email),
            Password.Create(password),
            name,
            PhoneNumber.Create(phoneNumber),
            Roles.SuperAdmin,
            AccountId.Create(accountId));
    }
}
