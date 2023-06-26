namespace iDelivery.Application.Common.Errors;

public class AddCommandError : IError
{
    public List<IError> Reasons => new();

    public string Message => "An error occurred while attempting to add a command";

    public Dictionary<string, object> Metadata => new();
}
