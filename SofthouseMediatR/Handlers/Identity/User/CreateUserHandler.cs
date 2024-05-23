using MediatR;
using SofthouseMediatR.Commands.Identity.User;
using SofthouseMediatR.Dto.Identity.User;
using SofthouseMediatR.Services.Interfaces;

namespace SofthouseMediatR.Handlers.Identity.User;

public class CreateUserHandler : IRequestHandler<CreateUserCommand, CreateUserResponse>
{
	private readonly IUserManagerService _userManagerService;

	public CreateUserHandler(IUserManagerService userManagerService)
	{
		_userManagerService = userManagerService;
	}

	public async Task<CreateUserResponse> Handle(CreateUserCommand request, CancellationToken cancellationToken)
	{
		return await _userManagerService.CreateUserAsync(request.CreateUserRequest, request.CreateUserRequest.Password);
	}
}
