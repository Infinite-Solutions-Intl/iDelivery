using iDelivery.Domain.AccountAggregate.ValueObjects;

namespace DomainTests.AccountAggregate.ValueObjects;

public class PhoneNumberTests
{
    [Fact]
    public void RestoreMethod_ShouldReturnCorrectPhoneNumber()
    {
        var phoneNumber1 = PhoneNumber.Create(699254549, 237);
        var phoneNumber2 = PhoneNumber.Restore(phoneNumber1.Value);

        Assert.Equal(phoneNumber1, phoneNumber2);
    }
}
