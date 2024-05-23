using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SofthouseMediatR.Dto.Identity.Role;
using SofthouseMediatR.Exceptions.RoleExceptions;
using SofthouseMediatR.Services.Interfaces;

namespace SofthouseMediatR.Services;

public class RoleManagerService : IRoleManagerService
{
	private readonly RoleManager<IdentityRole> _roleManager;
	private readonly IMapper _mapper;

	public RoleManagerService(RoleManager<IdentityRole> roleManager, IMapper mapper)
	{
		_roleManager = roleManager;
		_mapper = mapper;
	}

	public async Task<IEnumerable<GetRoleResponse>> GetRolesAsync()
	{
		var roles = _mapper.Map<IEnumerable<GetRoleResponse>>(_roleManager.Roles.AsNoTracking());

		return await Task.FromResult(roles);
	}

	public async Task<GetRoleResponse> GetRoleByIdAsync(string roleId)
	{
		var role = _mapper.Map<GetRoleResponse>(await _roleManager.FindByIdAsync(roleId));

		return role ?? throw new RoleNotFoundException(roleId);
	}

	public async Task<GetRoleResponse> GetRoleByNameAsync(string roleName)
	{
		var role = _mapper.Map<GetRoleResponse>(await _roleManager.FindByNameAsync(roleName));

		return role ?? throw new RoleNotFoundException(roleName);
	}

	public async Task<CreateRoleResponse> CreateRoleAsync(string roleName)
	{
		var fetchedRole = await _roleManager.FindByNameAsync(roleName);

		if (fetchedRole is not null)
		{
			throw new RoleAlreadyExistException(roleName);
		}

		var createdRole = await _roleManager.CreateAsync(new IdentityRole(roleName));

		return createdRole.Succeeded
			? _mapper.Map<CreateRoleResponse>(await _roleManager.FindByNameAsync(roleName))
			: throw new RoleNotCreatedException(string.Join(". ", createdRole.Errors));
	}

	public async Task<UpdateRoleResponse> UpdateRoleAsync(string id, string roleName)
	{
		var role = await _roleManager.FindByIdAsync(id);

		if (role is null)
		{
			throw new RoleNotFoundException(roleName);
		}

		role.Name = roleName;
		var result = await _roleManager.UpdateAsync(role);

		if (result.Succeeded)
		{
			return _mapper.Map<UpdateRoleResponse>(role);
		}

		throw new RoleNotUpdatedException(string.Join(", ", result.Errors));
	}

	public async Task DeleteRoleAsync(string roleId)
	{
		var role = await _roleManager.FindByIdAsync(roleId);

		if (role is null)
		{
			throw new RoleNotFoundException(roleId);
		}

		var result = await _roleManager.DeleteAsync(role);

		if (!result.Succeeded)
		{
			throw new RoleNotDeletedException(string.Join(". ", result.Errors));
		}
	}
}
