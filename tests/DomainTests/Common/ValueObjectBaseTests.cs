using iDelivery.Domain.AccountAggregate.ValueObjects;
using iDelivery.Domain.Common.Models;

namespace DomainTests.Common;

class ValueObject1 : ValueObject
{
    public UserId UserId { get; set; }
    public AccountId AccountId { get; set; }
    public Email Email { get; set; }
    public Password Password { get; set; }
    public PhoneNumber PhoneNumber { get; set; }

    public ValueObject1(
        UserId userId,
        AccountId accountId,
        Email email,
        Password password,
        PhoneNumber phoneNumber)
    {
        UserId = userId;
        AccountId = accountId;
        Email = email;
        Password = password;
        PhoneNumber = phoneNumber;
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return UserId;
        yield return AccountId;
        yield return Email;
        yield return Password;
        yield return PhoneNumber;
    }
}

public class ValueObjectBaseTests
{
    private UserId _userId = UserId.CreateUnique();
    private AccountId _accountId = AccountId.CreateUnique();
    private Email _email = Email.Create("djoufson@gmail.com");
    private Password _password = Password.Create("Unknown");
    private PhoneNumber _phoneNumber = PhoneNumber.Create(4);
    private ValueObject1 obj1 = null!;
    private ValueObject1 obj2 = null!;

    [Fact]
    public void ValueObjectsWithSameProperties_ShouldBeEquals()
    {
        SetUp();
        Assert.Equal(obj1, obj2);
    }

    [Fact]
    public void ValueObjectsOfSameType_ShouldHaveSameEqualityComponentsLength()
    {
        SetUp();
        Assert.Equal(obj1.GetEqualityComponents().Count(), obj2.GetEqualityComponents().Count());
        Assert.Equal(obj1.UserId.GetEqualityComponents().Count(), obj2.UserId.GetEqualityComponents().Count());
        Assert.Equal(obj1.AccountId.GetEqualityComponents().Count(), obj2.AccountId.GetEqualityComponents().Count());
        Assert.Equal(obj1.Email.GetEqualityComponents().Count(), obj2.Email.GetEqualityComponents().Count());
        Assert.Equal(obj1.Password.GetEqualityComponents().Count(), obj2.Password.GetEqualityComponents().Count());
        Assert.Equal(obj1.PhoneNumber.GetEqualityComponents().Count(), obj2.PhoneNumber.GetEqualityComponents().Count());
    }

    [Fact]
    public void CreateUniqueMethods_ShouldReturnUniqueValues()
    {
        SetUp();
        Assert.NotEqual(_userId, UserId.CreateUnique());
        Assert.NotEqual(UserId.CreateUnique(), UserId.CreateUnique());
        Assert.NotEqual(_accountId, AccountId.CreateUnique());
        Assert.NotEqual(AccountId.CreateUnique(), AccountId.CreateUnique());
    }

    [Fact]
    public void CreateMethods_ShouldRetrieveTheExactPreviousState()
    {
        SetUp();
        Assert.Equal(_userId, UserId.Create(_userId.Id));
        Assert.Equal(_accountId, AccountId.Create(_accountId.Id));
        Assert.Equal(_email, Email.Create(_email.Value));
        // Assert.Equal(_phoneNumber, PhoneNumber.Create(_phoneNumber.Value, _phoneNumber.CountryIdentifier));
        Assert.Equal(_password, Password.Create("Unknown"));
    }

    void SetUp()
    {
        _userId = UserId.CreateUnique();
        _accountId = AccountId.CreateUnique();
        _email = Email.Create("djoufson@gmail.com");
        _password = Password.Create("Unknown");
        _phoneNumber = PhoneNumber.Create(699254549);

        obj1 = new ValueObject1(
            _userId,
            _accountId,
            _email,
            _password,
            _phoneNumber);

        obj2 = new ValueObject1(
            _userId,
            _accountId,
            _email,
            _password,
            _phoneNumber);
    }
}
