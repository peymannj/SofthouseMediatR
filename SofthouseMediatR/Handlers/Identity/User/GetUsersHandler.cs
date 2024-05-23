using MediatR;
using SofthouseMediatR.Dto.Identity.User;
using SofthouseMediatR.Queries.Identity.User;
using SofthouseMediatR.Services.Interfaces;

namespace SofthouseMediatR.Handlers.Identity.User;

public class GetUsersHandler : IRequestHandler<GetUsersQuery, IEnumerable<GetUserResponse>>
{
	private readonly IUserManagerService _userManagerService;

	public GetUsersHandler(IUserManagerService userManagerService)
	{
		_userManagerService = userManagerService;
	}

	public async Task<IEnumerable<GetUserResponse>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
	{
		return await _userManagerService.GetUsersAsync();
	}
}
