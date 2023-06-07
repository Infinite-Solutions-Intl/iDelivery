namespace iDelivery.Domain.AccountAggregate.ValueObjects;

public sealed class PhoneNumber : ValueObject
{
    public int Value { get; }
    public int CountryIdentifier { get; }

    private PhoneNumber(int phoneNumber, int? countryIdentifier)
    {
        Value = phoneNumber;
        if (countryIdentifier is not null)
            CountryIdentifier = (int)countryIdentifier;
    }

    public static PhoneNumber Create(int phoneNumber, int? countryIdentifier = 237)
    {
        return new PhoneNumber(phoneNumber, countryIdentifier);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
        yield return CountryIdentifier;
    }

    public override string ToString()
    {
        return $"{CountryIdentifier} {Value}";
    }
}
