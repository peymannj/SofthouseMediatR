using MediatR;

namespace SofthouseMediatR.Commands.Identity.User;

public class RemoveUserFromRoleCommand : IRequest
{
	public string UserId { get; set; }
	public string Role { get; set; }
	
	public RemoveUserFromRoleCommand(string userId, string role)
	{
		UserId = userId;
		Role = role;
	}
}
