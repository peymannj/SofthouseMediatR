using MediatR;
using SofthouseMediatR.Dto.Identity.Role;
using SofthouseMediatR.Queries.Identity.Role;
using SofthouseMediatR.Services.Interfaces;

namespace SofthouseMediatR.Handlers.Identity.Role;

public class GetRolesHandler : IRequestHandler<GetRolesQuery, IEnumerable<GetRoleResponse>>
{
	private readonly IRoleManagerService _roleManagerService;

	public GetRolesHandler(IRoleManagerService roleManagerService)
	{
		_roleManagerService = roleManagerService;
	}

	public async Task<IEnumerable<GetRoleResponse>> Handle(GetRolesQuery request, CancellationToken cancellationToken)
	{
		return await _roleManagerService.GetRolesAsync();
	}
}
