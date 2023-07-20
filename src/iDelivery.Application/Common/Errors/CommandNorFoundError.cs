namespace iDelivery.Application.Common.Errors;

public class CommandNorFoundError : IError
{
    public List<IError> Reasons => new();

    public string Message => "The command does not exist";

    public Dictionary<string, object> Metadata => new();
}
