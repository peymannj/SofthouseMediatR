using System.Text.Json.Serialization;

namespace SofthouseMediatR.Dto.Identity.Role;

public class UpdateRoleResponse
{
	[JsonPropertyName("id")]
	public Guid Id { get; init; }
	
	[JsonPropertyName("name")] 
	public string Name { get; init; } = string.Empty;
}
