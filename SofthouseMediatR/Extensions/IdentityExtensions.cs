using Microsoft.AspNetCore.Identity;

namespace SofthouseMediatR.Extensions;

public static class IdentityExtensions
{
	public static string GetFormatedErrors(this IdentityResult result)
	{
		return string.Join(" ", result.Errors.Select(x => x.Description));
	}
}
