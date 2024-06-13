namespace SofthouseMediatR.Exceptions.RoleExceptions;

public class RoleNotFoundException : ArgumentException
{
	public RoleNotFoundException(string message) : base("User not found.")
	{
	}
}
