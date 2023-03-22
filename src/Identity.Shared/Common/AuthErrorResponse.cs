using System.Text.Json.Serialization;

namespace Identity.Shared.Common;

public class AuthErrorResponse
{
    [JsonPropertyName("error")]
    public string Error { get; set; } = string.Empty;
    [JsonPropertyName("error_description")]
    public string Description { get; set; } = string.Empty;

    public AuthErrorResponse(string error, string? description = null)
    {
        this.Error = error;
        if(description is not null) {this.Description = description;}
    }

    public AuthErrorResponse() { }
}
