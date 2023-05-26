using iDelivery.Domain.AccountAggregate.Entities;
using iDelivery.Domain.AccountAggregate.Enums;
using iDelivery.Domain.AccountAggregate.ValueObjects;
using iDelivery.Domain.RunnerAggregate.ValueObjects;
using iDelivery.Domain.SupervisorAggregate.ValueObjects;

namespace iDelivery.Domain.AccountAggregate;

public sealed class Supervisor : User
{
    private readonly List<RunnerId> _runnerIds = new();
    public IReadOnlyList<RunnerId> RunnerIds => _runnerIds.AsReadOnly();
    protected Supervisor(
        SupervisorId id,
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
    public static Supervisor Create(
        string email,
        string password,
        string name,
        int phoneNumber)
    {
        return new Supervisor(
            SupervisorId.CreateUnique(),
            Email.Create(email),
            Password.Create(password),
            name,
            PhoneNumber.Create(phoneNumber));
    }
}