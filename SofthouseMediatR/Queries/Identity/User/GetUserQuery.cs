using MediatR;
using SofthouseMediatR.Dto.Identity.User;

namespace SofthouseMediatR.Queries.Identity.User;

public class GetUserQuery : IRequest<GetUserResponse>
{
	public string Id { get; set; }

	public GetUserQuery(string id)
	{
		Id = id;
	}
}
