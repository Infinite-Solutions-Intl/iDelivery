using iDelivery.Domain.AccountAggregate.Exceptions;
using iDelivery.Domain.AccountAggregate.ValueObjects;

namespace DomainTests.AccountAggregate.ValueObjects;

public class PasswordTests
{
    [Fact]
    public void PasswordsHashes_ShouldBeEqualsWhenClearValuesAreSame()
    {
        var firstPassword = Password.Create("le tonton");
        var secondPassword = Password.Create("le tonton");
        Assert.Equal(firstPassword, secondPassword);
    }

    [Fact]
    public void PasswordsHashes_ShouldNotBeEqualsWhenClearValuesAreDifferent()
    {
        var firstPassword = Password.Create("le tonton");
        var secondPassword = Password.Create("le tonton ");
        Assert.NotEqual(firstPassword, secondPassword);
    }

    [Fact]
    public void Password_ShouldNotBeNullOrEmpty()
    {
        Assert.Throws<PasswordNotStrongEnoughtException>(() => { Password.Create(""); });
    }
}
