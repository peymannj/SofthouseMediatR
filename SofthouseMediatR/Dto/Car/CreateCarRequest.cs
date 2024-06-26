using System.Text.Json.Serialization;

namespace SofthouseMediatR.Dto.Car;

public class CreateCarRequest
{
    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;

    [JsonPropertyName("color")]
    public string Color { get; set; } = string.Empty;
}
