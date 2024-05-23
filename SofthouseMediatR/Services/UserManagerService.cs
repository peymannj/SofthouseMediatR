using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SofthouseMediatR.Dto.Identity.User;
using SofthouseMediatR.Exceptions.UserException;
using SofthouseMediatR.Services.Interfaces;

namespace SofthouseMediatR.Services;

public class UserManagerService : IUserManagerService
{
	private readonly UserManager<IdentityUser> _userManager;
	private readonly IMapper _mapper;

	public UserManagerService(UserManager<IdentityUser> userManager, IMapper mapper)
	{
		_userManager = userManager;
		_mapper = mapper;
	}

	public async Task<IEnumerable<GetUserResponse>> GetUsersAsync()
	{
		var users = _mapper.Map<IEnumerable<GetUserResponse>>(_userManager.Users.AsNoTracking());

		return await Task.FromResult(users);
	}

	public async Task<GetUserResponse> GetUserByIdAsync(string userId)
	{
		var user = _mapper.Map<GetUserResponse>(await _userManager.FindByIdAsync(userId));

		return user ?? throw new UserNotFoundException(userId);
	}

	public async Task<CreateUserResponse> CreateUserAsync(CreateUserRequest user, string password)
	{
		var fetchedUser = await _userManager.FindByEmailAsync(user.Email);

		if (fetchedUser is not null)
		{
			throw new UserAlreadyExistException(user.Email);
		}

		var userToCreate = _mapper.Map<IdentityUser>(user);
		var createdUser = await _userManager.CreateAsync(userToCreate, password);

		return createdUser.Succeeded
			? _mapper.Map<CreateUserResponse>(await _userManager.FindByEmailAsync(user.Email))
			: throw new UserNotCreatedException(string.Join(". ", createdUser.Errors));
	}

	public async Task<UpdateUserResponse> UpdateUserAsync(string userId, UpdateUserRequest updatedUser)
	{
		var user = await _userManager.FindByIdAsync(userId);

		if (user is null)
		{
			throw new UserNotFoundException(userId);
		}

		user.UserName = updatedUser.UserName;
		user.Email = updatedUser.Email;
		var result = await _userManager.UpdateAsync(user);

		if (result.Succeeded)
		{
			return _mapper.Map<UpdateUserResponse>(user);
		}

		throw new UserNotUpdatedException(string.Join(". ", result.Errors));
	}

	public async Task DeleteUserAsync(string userId)
	{
		var user = await _userManager.FindByIdAsync(userId);

		if (user is null)
		{
			throw new UserNotFoundException(userId);
		}

		var result = await _userManager.DeleteAsync(user);

		if (!result.Succeeded)
		{
			throw new UserNotDeletedException(string.Join("; ", result.Errors));
		}
	}

	public async Task AddToRoleAsync(string userId, string role)
	{
		var user = await _userManager.FindByIdAsync(userId);

		if (user is null)
		{
			throw new UserNotFoundException(userId);
		}

		var result = await _userManager.AddToRoleAsync(user, role);

		if (!result.Succeeded)
		{
			throw new AddToRoleException(string.Join("; ", result.Errors));
		}
	}

	public async Task RemoveFromRoleAsync(string userId, string role)
	{
		var user = await _userManager.FindByIdAsync(userId);

		if (user is null)
		{
			throw new UserNotFoundException(userId);
		}

		var result = await _userManager.RemoveFromRoleAsync(user, role);

		if (!result.Succeeded)
		{
			throw new AddToRoleException(string.Join("; ", result.Errors));
		}
	}
}
