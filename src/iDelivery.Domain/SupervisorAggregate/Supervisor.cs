using iDelivery.Domain.AccountAggregate.Entities;
using iDelivery.Domain.AccountAggregate.ValueObjects;
using iDelivery.Domain.Common.Utilities;
using iDelivery.Domain.RunnerAggregate.ValueObjects;
using iDelivery.Domain.SupervisorAggregate.ValueObjects;

namespace iDelivery.Domain.AccountAggregate;

public sealed class Supervisor : User
{
    private readonly List<RunnerId> _runnerIds = new();
    public IReadOnlyList<RunnerId> RunnerIds => _runnerIds.AsReadOnly();

    private Supervisor(
        SupervisorId id,
        Email email,
        Password password,
        string name,
        string role,
        PhoneNumber phoneNumber,
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

    public static Supervisor Create(
        string email,
        string password,
        string name,
        int phoneNumber,
        Guid accountId)
    {
        return new Supervisor(
            SupervisorId.CreateUnique(),
            Email.Create(email),
            Password.Create(password),
            name,
            Roles.Supervisor,
            PhoneNumber.Create(phoneNumber),
            AccountId.Create(accountId));
    }
}
