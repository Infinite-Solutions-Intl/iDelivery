namespace iDelivery.Application.Common.Errors;

public class UserNotFoundError : IError
{
    public List<IError> Reasons => new();

    public string Message { get; }

    public Dictionary<string, object> Metadata => new();

    public UserNotFoundError(string id)
    {
        Message = $"The user with Id: `{id}` does not or no longer exist";
    }
}
