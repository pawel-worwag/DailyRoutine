using System.Text.Json.Serialization;

namespace Identity.Shared.Commands.Auth.Tokens;

public class ErrorResponse
{
    [JsonPropertyName("error")]
    public string Error { get; set; } = string.Empty;
    [JsonPropertyName("error_description")]
    public string Description { get; set; } = string.Empty;

    public ErrorResponse(string error, string? description = null)
    {
        this.Error = error;
        if(description is not null) {this.Description = description;}
    }

    public ErrorResponse()
    {
            
    }
}

public static class ErrorResponseValues
{
    /// <summary>
    /// The request is missing a required parameter,
    /// includes an unsupported parameter value (other than grant type),
    /// repeats a parameter, or is otherwise malformed.
    /// </summary>
    public const string InvalidRequest = "invalid_request";
    /// <summary>
    /// Client authentication failed, due to missing or invalid client credentials.
    /// </summary>
    public const string InvalidClient = "invalid_client";
    /// <summary>
    /// The provided OAuth 2.0 grant is invalid, expired or has been revoked.
    /// May also indicate the redirect_uri parameter doesn't match (for a code grant).
    /// </summary>
    public const string InvalidGrant = "invalid_grant";
    /// <summary>
    /// The client is successfully authenticated,
    /// but it's not registered to use the submitted grant type.
    /// </summary>
    public const string UnauthorizedClient = "unauthorized_client";
    /// <summary>
    /// The grant type is not supported by the server.
    /// </summary>
    public const string UnsupportedGrantType = "unsupported_grant_type";
    /// <summary>
    /// The requested scope is invalid, unknown, malformed,
    /// or exceeds the scope granted by the resource owner.
    /// </summary>
    public const string InvalidScope = "invalid_scope";
    /// <summary>
    /// The request includes an invalid DPoP proof JWT.
    /// </summary>
    public const string InvalidDpopProof = "invalid_dpop_proof";
    
}