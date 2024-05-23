using MediatR;
using SofthouseMediatR.Dto.Identity.User;

namespace SofthouseMediatR.Commands.Identity.User;

public class UpdateUserCommand : IRequest<UpdateUserResponse>
{
	public UpdateUserRequest UpdateUserRequest { get; set; }
	
	public UpdateUserCommand(string id, UpdateUserRequest updateUserRequest)
	{
		UpdateUserRequest = updateUserRequest;
	}
}
