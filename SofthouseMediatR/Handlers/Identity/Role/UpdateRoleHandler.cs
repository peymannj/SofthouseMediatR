using MediatR;
using SofthouseMediatR.Commands.Identity.Role;
using SofthouseMediatR.Dto.Identity.Role;
using SofthouseMediatR.Services.Interfaces;

namespace SofthouseMediatR.Handlers.Identity.Role;

public class UpdateRoleHandler : IRequestHandler<UpdateRoleCommand, UpdateRoleResponse>
{
	private readonly IRoleManagerService _roleManagerService;

	public UpdateRoleHandler(IRoleManagerService roleManagerService)
	{
		_roleManagerService = roleManagerService;
	}

	public async Task<UpdateRoleResponse> Handle(UpdateRoleCommand request, CancellationToken cancellationToken)
	{
		return await _roleManagerService.UpdateRoleAsync(request.Id, request.Name);
	}
}
