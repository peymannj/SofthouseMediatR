using System.Text.Json.Serialization;

namespace SofthouseMediatR.Dto.Identity.Role;

public class UpdateRoleResponse
{
	[JsonPropertyName("id")]
	public Guid Id { get; set; }
	
	[JsonPropertyName("name")]
	public string Name { get; set; }
}
