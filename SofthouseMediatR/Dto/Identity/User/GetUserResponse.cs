using System.Text.Json.Serialization;

namespace SofthouseMediatR.Dto.Identity.User;

public class GetUserResponse
{
	[JsonPropertyName("id")]
	public Guid Id { get; init; }
	
	[JsonPropertyName("userName")]
	public string UserName { get; init; } = string.Empty;

	[JsonPropertyName("email")]
	public string Email { get; init; } = string.Empty;
}
