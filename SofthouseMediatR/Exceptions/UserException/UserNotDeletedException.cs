namespace SofthouseMediatR.Exceptions.UserException;

public class UserNotDeletedException : OperationCanceledException
{
	public UserNotDeletedException(string message) : base(message)
	{
	}
}
