namespace SofthouseMediatR.Exceptions.RoleExceptions;

public class RoleNotDeletedException : OperationCanceledException
{
	public RoleNotDeletedException(string message) : base(message)
	{
	}
}
