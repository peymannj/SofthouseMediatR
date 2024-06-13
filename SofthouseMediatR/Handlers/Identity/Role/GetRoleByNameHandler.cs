using MediatR;
using SofthouseMediatR.Dto.Identity.Role;
using SofthouseMediatR.Queries.Identity.Role;
using SofthouseMediatR.Services.Interfaces;

namespace SofthouseMediatR.Handlers.Identity.Role;

public class GetRoleByNameHandler : IRequestHandler<GetRoleByNameQuery, GetRoleResponse>
{
	private readonly IRoleManagerService _roleManagerService;

	public GetRoleByNameHandler(IRoleManagerService roleManagerService)
	{
		_roleManagerService = roleManagerService;
	}

	public async Task<GetRoleResponse> Handle(GetRoleByNameQuery request, CancellationToken cancellationToken)
	{
		return await _roleManagerService.GetRoleByNameAsync(request.Name);
	}
}
