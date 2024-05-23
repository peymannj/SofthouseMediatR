using MediatR;

namespace SofthouseMediatR.Commands.Identity.User;

public class RemoveUserFromRoleCommand : IRequest
{
	public string UserId { get; set; }
	public string RoleId { get; set; }
	
	public RemoveUserFromRoleCommand(string userId, string roleId)
	{
		UserId = userId;
		RoleId = roleId;
	}
}
