using System.Text.Json.Serialization;

namespace SofthouseMediatR.Dto.Car;

public class GetCarResponse
{
    [JsonPropertyName("id")]
    public Guid Id { get; init; }

    [JsonPropertyName("name")]
    public string Name { get; init; } = string.Empty;

    [JsonPropertyName("color")]
    public string Color { get; init; } = string.Empty;
}
