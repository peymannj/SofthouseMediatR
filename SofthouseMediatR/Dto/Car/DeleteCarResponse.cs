using System.Text.Json.Serialization;

namespace SofthouseMediatR.Dto.Car;

public class DeleteCarResponse
{
    [JsonPropertyName("id")]
    public Guid Id { get; init; }
}
