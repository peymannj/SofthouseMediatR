using MediatR;
using SofthouseMediatR.Dto.Identity.User;

namespace SofthouseMediatR.Commands.Identity.User;

public class CreateUserCommand : IRequest<CreateUserResponse>
{
	public CreateUserRequest CreateUserRequest { get; set; }

	public CreateUserCommand(CreateUserRequest createUserRequest)
	{
		CreateUserRequest = createUserRequest;
	}
}
