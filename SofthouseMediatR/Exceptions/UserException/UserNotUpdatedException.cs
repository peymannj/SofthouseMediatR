namespace SofthouseMediatR.Exceptions.UserException;

public class UserNotUpdatedException : OperationCanceledException
{
	public UserNotUpdatedException(string message) : base(message)
	{
	}
}
