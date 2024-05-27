using MediatR;

namespace SofthouseMediatR.Commands.Identity.User;

public class AddUserToRoleCommand : IRequest
{
	public string UserId { get; set; }
	public string Role { get; set; }
	
	public AddUserToRoleCommand(string userId, string role)
	{
		UserId = userId;
		Role = role;
	}
}
