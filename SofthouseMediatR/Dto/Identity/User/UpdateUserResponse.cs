using System.Text.Json.Serialization;

namespace SofthouseMediatR.Dto.Identity.User;

public class UpdateUserResponse
{
	[JsonPropertyName("id")]
	public Guid Id { get; set; }
	
	[JsonPropertyName("userName")]
	public string UserName { get; set; }

	[JsonPropertyName("email")]
	public string Email { get; set; }
}
