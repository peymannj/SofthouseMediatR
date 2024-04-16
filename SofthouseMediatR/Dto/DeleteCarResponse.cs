using System.Text.Json.Serialization;

namespace SofthouseMediatR.Dto;

public class DeleteCarResponse
{
    [JsonPropertyName("id")]
    public Guid Id { get; init; }
}
