using System.Text.Json.Serialization;

namespace DailyRoutine.Shared.Infrastructure.Exceptions.Dto;

public record ErrorResponse
{

    [JsonPropertyName("errors")] 
    public ICollection<string> Errors { get; init; } = new List<string>();
}