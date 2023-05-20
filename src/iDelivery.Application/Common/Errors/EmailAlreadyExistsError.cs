namespace iDelivery.Application.Common.Errors;

public class EmailAlreadyExistsError : IError
{
    public List<IError> Reasons => new();

    public string Message => "This email is already registered";

    public Dictionary<string, object> Metadata => new();
}
