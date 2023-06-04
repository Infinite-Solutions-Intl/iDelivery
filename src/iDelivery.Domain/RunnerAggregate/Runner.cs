using iDelivery.Domain.AccountAggregate.Entities;
using iDelivery.Domain.AccountAggregate.Enums;
using iDelivery.Domain.AccountAggregate.ValueObjects;
using iDelivery.Domain.RunnerAggregate.ValueObjects;
using iDelivery.Domain.SupervisorAggregate.ValueObjects;

namespace iDelivery.Domain.AccountAggregate;

public sealed class Runner : User
{
    public SupervisorId SupervisorId{get; set;}
    private Runner(
        RunnerId id,
        Email email,
        Password password,
        string name,
        PhoneNumber phoneNumber,
        SupervisorId supervisorId,
        AccountId accountId) : base(
            id,
            email,
            password,
            name,
            phoneNumber,
            accountId)
    {
        SupervisorId = supervisorId; 
    }

    public static Runner Create (
        string email,
        string password,
        string name,
        int phoneNumber,
        Guid supervisorId,
        Guid accountId)
    {
        return new Runner(
            RunnerId.CreateUnique(),
            Email.Create(email),
            Password.Create(password),
            name,
            PhoneNumber.Create(phoneNumber),
            SupervisorId.Create(supervisorId),
            AccountId.Create(accountId));
    }
}