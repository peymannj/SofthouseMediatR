﻿using System.Text.Json.Serialization;

namespace SofthouseMediatR.Dto.Identity.User;

public class AddToRoleRequest
{
	[JsonPropertyName("userId")]
	public string UserId { get; set; } = string.Empty;
	
	[JsonPropertyName("role")]
	public string Role { get; set; } = string.Empty;
}
