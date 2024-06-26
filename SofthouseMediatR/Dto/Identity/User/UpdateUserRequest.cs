using System.Text.Json.Serialization;

namespace SofthouseMediatR.Dto.Identity.User;

public class UpdateUserRequest
{
	[JsonPropertyName("id")]
	public string Id { get; set; } = string.Empty;
	
	[JsonPropertyName("userName")]
	public string UserName { get; set; } = string.Empty;

	[JsonPropertyName("email")]
	public string Email { get; set; } = string.Empty;
}
