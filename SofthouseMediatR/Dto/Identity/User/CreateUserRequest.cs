using System.Text.Json.Serialization;

namespace SofthouseMediatR.Dto.Identity.User;

public class CreateUserRequest
{
	[JsonPropertyName("email")]
	public string Email { get; set; }

	[JsonPropertyName("password")]
	public string Password { get; set; }
}
