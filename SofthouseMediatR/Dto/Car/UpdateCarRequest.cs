using System.Text.Json.Serialization;

namespace SofthouseMediatR.Dto.Car;

public class UpdateCarRequest
{
    [JsonPropertyName("id")]
    public Guid Id { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("color")]
    public string Color { get; set; }
}
