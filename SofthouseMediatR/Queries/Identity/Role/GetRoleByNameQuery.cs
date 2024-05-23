using MediatR;
using SofthouseMediatR.Dto.Identity.Role;

namespace SofthouseMediatR.Queries.Identity.Role;

public class GetRoleByNameQuery : IRequest<GetRoleResponse>
{
	public string Name { get; }

	public GetRoleByNameQuery(string name)
	{
		Name = name;
	}
}
