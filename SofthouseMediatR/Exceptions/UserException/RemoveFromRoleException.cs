namespace SofthouseMediatR.Exceptions.UserException;

public class RemoveFromRoleException : OperationCanceledException
{
	public RemoveFromRoleException(string message) : base(message)
	{
	}
}
