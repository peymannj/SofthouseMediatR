using SofthouseMediatR.Dto.Identity.Role;

namespace SofthouseMediatR.Services.Interfaces;

public interface IRoleManagerService
{
	Task<IEnumerable<GetRoleResponse>> GetRolesAsync();

	Task<GetRoleResponse> GetRoleByIdAsync(string roleId);

	Task<GetRoleResponse> GetRoleByNameAsync(string roleName);

	Task<CreateRoleResponse> CreateRoleAsync(string roleName);

	Task<UpdateRoleResponse> UpdateRoleAsync(string id, string roleName);

	Task DeleteRoleAsync(string roleId);
}
