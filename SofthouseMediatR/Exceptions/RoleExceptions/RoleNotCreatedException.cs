namespace SofthouseMediatR.Exceptions.RoleExceptions;

public class RoleNotCreatedException : OperationCanceledException
{
	public RoleNotCreatedException(string message) : base(message)
	{
	}
}
