namespace SofthouseMediatR.Exceptions.UserException;

public class UserAlreadyExistException : ArgumentException
{
	public UserAlreadyExistException(string email) : base($"User with email '{email} already exist.")
	{
	}
}
