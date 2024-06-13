using SofthouseMediatR.Dto.Identity.User;

namespace SofthouseMediatR.Services.Interfaces;

public interface IUserManagerService
{
	Task<IEnumerable<GetUserResponse>> GetUsersAsync();

	Task<GetUserResponse> GetUserByIdAsync(string userId);

	Task<CreateUserResponse> CreateUserAsync(CreateUserRequest user, string password);

	Task<UpdateUserResponse> UpdateUserAsync(string userId, UpdateUserRequest updatedUser);

	Task DeleteUserAsync(string userId);

	Task AddToRoleAsync(string userId, string role);

	Task RemoveFromRoleAsync(string userId, string role);
}
