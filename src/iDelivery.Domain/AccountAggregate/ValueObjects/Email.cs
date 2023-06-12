using iDelivery.Domain.AccountAggregate.Exceptions;

namespace iDelivery.Domain.AccountAggregate.ValueObjects;

public sealed class Email : ValueObject
{
    public string Value { get; }
    private Email(string value)
    {
        Value = value;
    }

    #pragma warning disable CS8618
    private Email()
    {
        
    }
    #pragma warning restore CS8618

    public static Email Create(string email)
    {
        return IsValid(email) ? new Email(email) : throw new EmailNotValidException();
    }

    private static bool IsValid(string email)
    {
        // Email validation here
        return !string.IsNullOrEmpty(email);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
