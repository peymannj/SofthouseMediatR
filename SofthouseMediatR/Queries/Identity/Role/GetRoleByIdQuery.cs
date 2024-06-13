using MediatR;
using SofthouseMediatR.Dto.Identity.Role;

namespace SofthouseMediatR.Queries.Identity.Role;

public class GetRoleByIdQuery : IRequest<GetRoleResponse>
{
	public string Id { get; }

	public GetRoleByIdQuery(string id)
	{
		Id = id;
	}
}
