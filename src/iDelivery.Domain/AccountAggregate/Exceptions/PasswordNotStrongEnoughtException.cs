namespace iDelivery.Domain.AccountAggregate.Exceptions;

public class PasswordNotStrongEnoughtException : Exception
{
	private readonly string _message;

	public override string Message => _message;
	public PasswordNotStrongEnoughtException(string hint)
	{
		_message = $"The password does not match format requirements: {hint}";
	}
}
