using MediatR;
using SofthouseMediatR.Commands.Identity.User;
using SofthouseMediatR.Services.Interfaces;

namespace SofthouseMediatR.Handlers.Identity.User;

public class DeleteUserHandler : IRequestHandler<DeleteUserCommand>
{
	private readonly IUserManagerService _userManagerService;

	public DeleteUserHandler(IUserManagerService userManagerService)
	{
		_userManagerService = userManagerService;
	}

	public async Task Handle(DeleteUserCommand request, CancellationToken cancellationToken)
	{
		await _userManagerService.DeleteUserAsync(request.Id);
	}
}
