using MediatR;
using SofthouseMediatR.Dto.Identity.Role;

namespace SofthouseMediatR.Commands.Identity.Role;

public class CreateRoleCommand : IRequest<CreateRoleResponse>
{
	public string Name { get; set; }

	public CreateRoleCommand(string name)
	{
		Name = name;
	}
}
