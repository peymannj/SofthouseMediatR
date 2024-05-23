using MediatR;
using SofthouseMediatR.Commands.Identity.Role;
using SofthouseMediatR.Dto.Identity.Role;
using SofthouseMediatR.Services.Interfaces;

namespace SofthouseMediatR.Handlers.Identity.Role;

public class CreateRoleHandler : IRequestHandler<CreateRoleCommand, CreateRoleResponse>
{
	private readonly IRoleManagerService _roleManagerService;

	public CreateRoleHandler(IRoleManagerService roleManagerService)
	{
		_roleManagerService = roleManagerService;
	}

	public async Task<CreateRoleResponse> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
	{
		return await _roleManagerService.CreateRoleAsync(request.Name);
	}
}
