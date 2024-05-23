using MediatR;
using SofthouseMediatR.Commands.Identity.User;
using SofthouseMediatR.Dto.Identity.User;
using SofthouseMediatR.Services.Interfaces;

namespace SofthouseMediatR.Handlers.Identity.User;

public class UpdateUserHandler : IRequestHandler<UpdateUserCommand, UpdateUserResponse>
{
	private readonly IUserManagerService _userManagerService;

	public UpdateUserHandler(IUserManagerService userManagerService)
	{
		_userManagerService = userManagerService;
	}

	public async Task<UpdateUserResponse> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
	{
		return await _userManagerService.UpdateUserAsync(request.UpdateUserRequest.Id, request.UpdateUserRequest);
	}
}
