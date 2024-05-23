using MediatR;
using SofthouseMediatR.Dto.Identity.Role;

namespace SofthouseMediatR.Commands.Identity.Role;

public class UpdateRoleCommand : IRequest<UpdateRoleResponse>
{
	public string Id { get; set; }
	public string Name { get; set; }

	public UpdateRoleCommand(string id, string name)
	{
		Id = id;
		Name = name;
	}
}
