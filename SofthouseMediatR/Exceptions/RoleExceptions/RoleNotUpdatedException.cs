namespace SofthouseMediatR.Exceptions.RoleExceptions;

public class RoleNotUpdatedException : OperationCanceledException
{
	public RoleNotUpdatedException(string message) : base(message)
	{
	}
}
