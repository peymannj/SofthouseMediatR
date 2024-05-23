using MediatR;
using SofthouseMediatR.Dto.Identity.User;

namespace SofthouseMediatR.Queries.Identity.User;

public class GetUsersQuery : IRequest<IEnumerable<GetUserResponse>>
{
}
