namespace iDelivery.Domain.AccountAggregate.Exceptions;

public class EmailNotValidException : Exception
{
	private readonly string _message;
	public override string Message => _message;
	public EmailNotValidException(string? hint = "")
	{
		_message = $"The given email is not in a correct format: {hint}";
    }
}
