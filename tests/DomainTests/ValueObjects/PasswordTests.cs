using iDelivery.Domain.AccountAggregate.Exceptions;
using iDelivery.Domain.AccountAggregate.ValueObjects;

namespace DomainTests.ValueObjects;

public class PasswordTests
{
    [Fact]
    public void Passwords_Hashes_ShouldBeEqualsWhenClearValuesAreSame()
    {
        var firstPassword = Password.Create("le tonton");
        var secondPassword = Password.Create("le tonton");
        Assert.Equal(firstPassword, secondPassword);
    }

    [Fact]
    public void Passwords_Hashes_ShouldNotBeEqualsWhenClearValuesAreDifferent()
    {
        var firstPassword = Password.Create("le tonton");
        var secondPassword = Password.Create("le tonton ");
        Assert.NotEqual(firstPassword, secondPassword);
    }

    [Fact]
    public void Password_ShouldNotBeNullOrEmpty()
    {
        try
        {
            var password = Password.Create("");
            Assert.True(false);
        }
        catch (PasswordNotStrongEnoughtException)
        {
            Assert.True(true);
        }
    }
}