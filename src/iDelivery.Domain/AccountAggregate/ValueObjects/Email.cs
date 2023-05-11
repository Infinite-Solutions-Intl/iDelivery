using iDelivery.Domain.AccountAggregate.Exceptions;

namespace iDelivery.Domain.AccountAggregate.ValueObjects;

public sealed class Email : ValueObject
{
    public string Value { get; private set; }
    private Email(string value)
    {
        Value = value;
    }

    public static Email Create(string email)
    {
        return IsValid(email) ? new Email(email) : throw new EmailNotValidException();
    }

    private static bool IsValid(string email)
    {
        // Email validation here

        return true;
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
