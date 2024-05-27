using MediatR;
using SofthouseMediatR.Commands.Identity.User;
using SofthouseMediatR.Services.Interfaces;

namespace SofthouseMediatR.Handlers.Identity.User;

public class RemoveUserFromRoleHandler : IRequestHandler<RemoveUserFromRoleCommand>
{
	private readonly IUserManagerService _userManagerService;

	public RemoveUserFromRoleHandler(IUserManagerService userManagerService)
	{
		_userManagerService = userManagerService;
	}

	public async Task Handle(RemoveUserFromRoleCommand request, CancellationToken cancellationToken)
	{
		await _userManagerService.RemoveFromRoleAsync(request.UserId, request.Role);
	}
}
