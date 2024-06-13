namespace SofthouseMediatR.Exceptions.UserException;

public class UserNotCreatedException : OperationCanceledException
{
	public UserNotCreatedException(string message) : base(message)
	{
	}
}
