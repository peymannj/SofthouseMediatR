using System.Text.Json.Serialization;

namespace SofthouseMediatR.Dto.Identity.Role;

public class UpdateRoleRequest
{
	[JsonPropertyName("id")]
	public string Id { get; set; }
	
	[JsonPropertyName("name")]
	public string Name { get; set; }
}
