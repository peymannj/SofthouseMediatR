using MediatR;

namespace SofthouseMediatR.Commands.Identity.User;

public class DeleteUserCommand : IRequest
{
	public string Id { get; set; }

	public DeleteUserCommand(string id)
	{
		Id = id;
	}
}
