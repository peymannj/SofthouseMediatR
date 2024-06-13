using MediatR;
using SofthouseMediatR.Commands.Identity.Role;
using SofthouseMediatR.Services.Interfaces;

namespace SofthouseMediatR.Handlers.Identity.Role;

public class DeleteRoleHandler : IRequestHandler<DeleteRoleCommand>
{
	private readonly IRoleManagerService _roleManagerService;

	public DeleteRoleHandler(IRoleManagerService roleManagerService)
	{
		_roleManagerService = roleManagerService;
	}

	public async Task Handle(DeleteRoleCommand request, CancellationToken cancellationToken)
	{
		await _roleManagerService.DeleteRoleAsync(request.Id);
	}
}
