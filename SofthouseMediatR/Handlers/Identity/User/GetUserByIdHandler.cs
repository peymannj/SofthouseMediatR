using MediatR;
using SofthouseMediatR.Dto.Identity.User;
using SofthouseMediatR.Queries.Identity.User;
using SofthouseMediatR.Services.Interfaces;

namespace SofthouseMediatR.Handlers.Identity.User;

public class GetUserByIdHandler : IRequestHandler<GetUserQuery, GetUserResponse>
{
	private readonly IUserManagerService _userManagerService;

	public GetUserByIdHandler(IUserManagerService userManagerService)
	{
		_userManagerService = userManagerService;
	}

	public async Task<GetUserResponse> Handle(GetUserQuery request, CancellationToken cancellationToken)
	{
		return await _userManagerService.GetUserByIdAsync(request.Id);
	}
}
