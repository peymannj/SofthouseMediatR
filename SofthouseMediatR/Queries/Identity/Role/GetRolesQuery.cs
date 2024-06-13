using MediatR;
using SofthouseMediatR.Dto.Identity.Role;

namespace SofthouseMediatR.Queries.Identity.Role;

public class GetRolesQuery : IRequest<IEnumerable<GetRoleResponse>>
{
}
