namespace SofthouseMediatR.Exceptions.UserException;

public class UserNotFoundException : ArgumentException
{
	public UserNotFoundException(string message) : base($"User not found.")
	{
	}
}
