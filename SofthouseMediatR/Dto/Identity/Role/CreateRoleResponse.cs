using System.Text.Json.Serialization;

namespace SofthouseMediatR.Dto.Identity.Role;

public class CreateRoleResponse
{
	[JsonPropertyName("id")]
	public Guid Id { get; set; }

	[JsonPropertyName("name")]
	public string Name { get; set; } = string.Empty;
}
