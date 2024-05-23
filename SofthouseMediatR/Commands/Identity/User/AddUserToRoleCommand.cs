using MediatR;

namespace SofthouseMediatR.Commands.Identity.User;

public class AddUserToRoleCommand : IRequest
{
	public string UserId { get; set; }
	public string RoleId { get; set; }
	
	public AddUserToRoleCommand(string userId, string roleId)
	{
		UserId = userId;
		RoleId = roleId;
	}
}
