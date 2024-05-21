using Microsoft.AspNetCore.Identity;

namespace SofthouseMediatR.DataContext;

public class IdentityDataSeeder
{
	public static async Task SeedRolesAndUsers(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
	{
		if (!await roleManager.RoleExistsAsync("Admin"))
		{
			await roleManager.CreateAsync(new IdentityRole("Admin"));
		}

		if (!await roleManager.RoleExistsAsync("User"))
		{
			await roleManager.CreateAsync(new IdentityRole("User"));
		}

		if (await userManager.FindByEmailAsync("admin@example.com") is null)
		{
			var adminUser = new IdentityUser
			{
				UserName = "admin@example.com",
				Email = "admin@example.com",
			};
			
			var adminResult = await userManager.CreateAsync(adminUser, "Admin@123");
			
			if (adminResult.Succeeded)
			{
				await userManager.AddToRoleAsync(adminUser, "Admin");
			}
		}
		
		if (await userManager.FindByEmailAsync("user@example.com") is null)
		{
			var adminUser = new IdentityUser
			{
				UserName = "user@example.com",
				Email = "user@example.com",
			};
			
			var adminResult = await userManager.CreateAsync(adminUser, "User@123");
			
			if (adminResult.Succeeded)
			{
				await userManager.AddToRoleAsync(adminUser, "User");
			}
		}
	}
}
