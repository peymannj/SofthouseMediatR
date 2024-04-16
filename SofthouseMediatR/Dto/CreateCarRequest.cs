using System.Text.Json.Serialization;

namespace SofthouseMediatR.Dto;

public class CreateCarRequest
{
    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("color")]
    public string Color { get; set; }
}
