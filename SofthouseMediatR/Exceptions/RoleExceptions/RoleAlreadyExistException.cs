namespace SofthouseMediatR.Exceptions.RoleExceptions;

public class RoleAlreadyExistException : ArgumentException
{
	public RoleAlreadyExistException(string roleName) : base($"User role '{roleName} already exist.")
	{
	}
}
