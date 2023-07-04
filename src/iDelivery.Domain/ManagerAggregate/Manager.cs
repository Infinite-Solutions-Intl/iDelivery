using iDelivery.Domain.AccountAggregate.Entities;
using iDelivery.Domain.AccountAggregate.ValueObjects;
using iDelivery.Domain.Common.Utilities;
using iDelivery.Domain.Common.ValueObjects;
using iDelivery.Domain.ManagerAggregate.ValueObjects;

namespace iDelivery.Domain.ManagerAggregate;

public sealed class Manager : User
{
    private readonly List<ComplaintId> _complaintIds = new();
    public IReadOnlyList<ComplaintId> ComplaintIds => _complaintIds.AsReadOnly();
    private Manager(
        ManagerId id,
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

    private Manager()
    {

    }

    public static Manager Create(
        Email email,
        Password password,
        string name,
        PhoneNumber phoneNumber,
        AccountId accountId)
    {
        return new Manager(
            ManagerId.CreateUnique(),
            email,
            password,
            name,
            phoneNumber,
            Roles.Manager,
            accountId);
    }
}
