using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SofthouseMediatR.Enums;

namespace SofthouseMediatR.Extensions;

public static class DatabaseContextExtensions
{
	public static void SeedIdentityData(this ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<IdentityRole>().HasData(
			new IdentityRole
			{
				Id = "89c1c517-814f-48a6-8eff-c54ae3bfa73d",
				Name = Roles.Admin.ToString(),
				NormalizedName = Roles.Admin.ToString().ToUpper()
			},
			new IdentityRole
			{
				Id = "200a6dfb-003b-4351-9208-29c79a0eab6f",
				Name = Roles.Basic.ToString(),
				NormalizedName = Roles.Basic.ToString().ToUpper()
			});

		var hasher = new PasswordHasher<IdentityUser>();
		modelBuilder.Entity<IdentityUser>().HasData(new IdentityUser
			{
				Id = "1bbf10d6-aa5d-45b1-953b-36497b97bc5e",
				UserName = "admin@example.com",
				NormalizedUserName = "ADMIN@EXAMPLE.COM",
				Email = "admin@example.com",
				NormalizedEmail = "ADMIN@EXAMPLE.COM",
				EmailConfirmed = true,
				PasswordHash = hasher.HashPassword(null, "Admin@123")
			},
			new IdentityUser
			{
				Id = "3f66a20b-f193-449e-a636-8b669a1e43a7",
				UserName = "user@example.com",
				NormalizedUserName = "USER@EXAMPLE.COM",
				Email = "user@example.com",
				NormalizedEmail = "USER@EXAMPLE.COM",
				EmailConfirmed = true,
				PasswordHash = hasher.HashPassword(null, "User@123")
			});

		modelBuilder.Entity<IdentityUserRole<string>>().HasData(
			new IdentityUserRole<string>
				{ UserId = "1bbf10d6-aa5d-45b1-953b-36497b97bc5e", RoleId = "89c1c517-814f-48a6-8eff-c54ae3bfa73d" },
			new IdentityUserRole<string>
				{ UserId = "3f66a20b-f193-449e-a636-8b669a1e43a7", RoleId = "200a6dfb-003b-4351-9208-29c79a0eab6f" });
	}
}
