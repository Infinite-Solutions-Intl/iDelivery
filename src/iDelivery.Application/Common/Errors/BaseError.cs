namespace iDelivery.Application.Common.Errors;

public class BaseError : IError
{
    public List<IError> Reasons => new ();

    public string Message { get; }

    public Dictionary<string, object> Metadata => new();

    public BaseError(string message)
    {
        Message = message;
    }
}
