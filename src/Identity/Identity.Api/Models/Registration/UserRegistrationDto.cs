using System.Text.Json.Serialization;

namespace Identity.Api.Models.Registration;

public record UserRegistrationDto
{
    [JsonPropertyName("normalized-email")]
    public required string NormalizedEmail { get; init; }
}