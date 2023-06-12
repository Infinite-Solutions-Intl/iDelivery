namespace iDelivery.Domain.AccountAggregate.ValueObjects;

public sealed class PhoneNumber : ValueObject
{
    // public string Value => $"+{CountryIdentifier} {Number}";
    public string Value { get; }
    private readonly int _number;
    private readonly int _countryIdentifier;

    private PhoneNumber(int phoneNumber, int? countryIdentifier)
    {
        _number = phoneNumber;
        if (countryIdentifier is not null)
            _countryIdentifier = (int)countryIdentifier;
        Value = $"+{_countryIdentifier} {_number}";
    }
    private PhoneNumber(string fullNumber)
    {
        Value = fullNumber;
    }

    #pragma warning disable CS8618
    public PhoneNumber()
    {
        
    }
    #pragma warning restore CS8618

    public static PhoneNumber Create(int phoneNumber, int? countryIdentifier = 237)
    {
        return new PhoneNumber(phoneNumber, countryIdentifier);
    }
    
    public static PhoneNumber Create(string fullNumber)
    {
        return new PhoneNumber(fullNumber);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return _number;
        yield return _countryIdentifier;
    }

    public override string ToString()
    {
        return $"{_countryIdentifier} {_number}";
    }
}
