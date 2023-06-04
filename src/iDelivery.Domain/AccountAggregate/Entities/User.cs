﻿using iDelivery.Domain.AccountAggregate.ValueObjects;

namespace iDelivery.Domain.AccountAggregate.Entities;

public class User : Entity<UserId>
{
    public Email Email { get; set; }
    public Password Password { get; set; }
    public string Name { get; set; }
    public PhoneNumber PhoneNumber { get; set; }
    public AccountId AccountId{get; set;}

    protected User(
        UserId id,
        Email email,
        Password password,
        string name,
        PhoneNumber phoneNumber,
        AccountId accountId) : base(id)
    {
        Email = email;
        Password = password;
        Name = name;
        PhoneNumber = phoneNumber;
        AccountId = accountId;
    }

    public static User Create(
        string email,
        string password,
        string name,
        int phoneNumber,
        Guid accountId)
    {
        return new User(
            UserId.CreateUnique(),
            Email.Create(email),
            Password.Create(password),
            name,
            PhoneNumber.Create(phoneNumber),
            AccountId.Create(accountId));
    }
}
