namespace SofthouseMediatR.Exceptions.UserException;

internal class AddToRoleException : OperationCanceledException
{
	public AddToRoleException(string message) : base(message)
	{
	}
}
