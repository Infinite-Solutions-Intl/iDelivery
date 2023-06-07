namespace iDelivery.Domain.AccountAggregate.Exceptions;

public class PasswordNotStrongEnoughException : Exception
{
	private readonly string _message;

	public override string Message => _message;
	public PasswordNotStrongEnoughException(string hint)
	{
		_message = $"The password does not match format requirements: {hint}";
	}

    public PasswordNotStrongEnoughException() : base()
    {
		_message = "The password does not match format requirements";
    }

    public PasswordNotStrongEnoughException(string? message, Exception? innerException) : base(message, innerException)
    {
		_message = message ?? "The password does not match format requirements";
    }
}
