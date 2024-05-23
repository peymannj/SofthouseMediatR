using MediatR;

namespace SofthouseMediatR.Commands.Identity.Role;

public class DeleteRoleCommand : IRequest
{
	public string Id { get; set; }

	public DeleteRoleCommand(string id)
	{
		Id = id;
	}
}
