using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Identity.Api.Models.Auth;

public record AuthorizationResponse
{
    
    [JsonPropertyName("code")]
    [Required]
    public required string Code { get; init; }

    [JsonPropertyName("state")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? State { get; init; } = null;
}