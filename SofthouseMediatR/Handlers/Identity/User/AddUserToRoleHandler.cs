using MediatR;
using SofthouseMediatR.Commands.Identity.User;
using SofthouseMediatR.Services.Interfaces;

namespace SofthouseMediatR.Handlers.Identity.User;

public class AddUserToRoleHandler : IRequestHandler<AddUserToRoleCommand>
{
	private readonly IUserManagerService _userManagerService;

	public AddUserToRoleHandler(IUserManagerService userManagerService)
	{
		_userManagerService = userManagerService;
	}

	public async Task Handle(AddUserToRoleCommand request, CancellationToken cancellationToken)
	{
		await _userManagerService.AddToRoleAsync(request.UserId, request.Role);
	}
}
