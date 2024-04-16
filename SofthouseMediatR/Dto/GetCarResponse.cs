using System.Text.Json.Serialization;

namespace SofthouseMediatR.Dto;

public class GetCarResponse
{
    [JsonPropertyName("id")]
    public Guid Id { get; init; }

    [JsonPropertyName("name")]
    public string Name { get; init; }

    [JsonPropertyName("color")]
    public string Color { get; init; }
}
