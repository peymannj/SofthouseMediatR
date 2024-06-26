using System.Text.Json.Serialization;

namespace SofthouseMediatR.Dto.Identity.Role;

public class CreateRoleRequest
{
	[JsonPropertyName("name")] 
	public string Name { get; set; } = string.Empty;
}
