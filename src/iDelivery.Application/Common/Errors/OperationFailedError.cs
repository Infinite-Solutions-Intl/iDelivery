namespace iDelivery.Application.Common.Errors;

public class OperationFailedError : IError
{
    public List<IError> Reasons => new();

    public string Message { get; }

    public Dictionary<string, object> Metadata => new();
    public OperationFailedError(string message = "The operation failed unexpectedly")
    {
        Message = message;
    }
}
