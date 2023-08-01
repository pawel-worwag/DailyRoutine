using System.Text.Json.Serialization;

namespace DailyRoutine.Shared.Infrastructure.Exceptions.Dto;

public record ErrorResponse
{
    [JsonPropertyName("error")]
    public string Error { get; set; } = string.Empty;
    [JsonPropertyName("error_description")]
    public string Description { get; set; } = string.Empty;
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("error_details")] 
    public IDictionary<string,string>? Details { get; init; } = null;
}
