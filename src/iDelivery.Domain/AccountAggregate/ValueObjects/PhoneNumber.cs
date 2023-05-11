namespace iDelivery.Domain.AccountAggregate.ValueObjects;

public class PhoneNumber : ValueObject
{
    private readonly int _number;
    private readonly int _countryIdentifier;

    private PhoneNumber(int phoneNumber, int? countryIdentifier)
    {
        _number = phoneNumber;
        if (countryIdentifier is not null)
            _countryIdentifier = (int)countryIdentifier;
    }

    public static PhoneNumber Create(int phoneNumber, int? countryIdentifier = 237)
    {
        return new PhoneNumber(phoneNumber, countryIdentifier);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return _number;
        yield return _countryIdentifier;
    }
}
