using MediatR;
using SofthouseMediatR.Dto.Identity.Role;
using SofthouseMediatR.Queries.Identity.Role;
using SofthouseMediatR.Services.Interfaces;

namespace SofthouseMediatR.Handlers.Identity.Role;

public class GetRoleByIdHandler : IRequestHandler<GetRoleByIdQuery, GetRoleResponse>
{
	private readonly IRoleManagerService _roleManagerService;

	public GetRoleByIdHandler(IRoleManagerService roleManagerService)
	{
		_roleManagerService = roleManagerService;
	}

	public async Task<GetRoleResponse> Handle(GetRoleByIdQuery request, CancellationToken cancellationToken)
	{
		return await _roleManagerService.GetRoleByIdAsync(request.Id);
	}
}
