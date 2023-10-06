using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Identity.Api.Models.Auth;

/// <summary>
/// 
/// </summary>
public record OpenIdConfiguration
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="conf"></param>
    /// <returns></returns>
    public static explicit operator OpenIdConfiguration(Application.Auth.GetDiscovery.OpenIdConfiguration conf) => new OpenIdConfiguration()
    {
        Issuer = conf.Issuer,
        AuthorizationEndpoint = conf.AuthorizationEndpoint,
        TokenEndpoint = conf.TokenEndpoint,
        JwksUri = conf.JwksUri,
        ScopesSupported = conf.ScopesSupported,
        ResponseTypesSupported = conf.ResponseTypesSupported,
        SubjectTypesSupported = conf.SubjectTypesSupported,
        IdTokenSigningAlgValuesSupported = conf.IdTokenSigningAlgValuesSupported,
        ClaimsSupported = conf.ClaimsSupported
    };

    /// <summary>
    /// URL using the https scheme with no query or fragment component that the OP asserts as its Issuer Identifier. If Issuer discovery is supported, this value MUST be identical to the issuer value returned by WebFinger. This also MUST be identical to the iss Claim value in ID Tokens issued from this Issuer.
    /// </summary>
    [JsonPropertyName("issuer")]
    [Required]
    [MinLength(0)]
    public required string Issuer { get; init; }
    
    /// <summary>
    /// URL of the OAuth 2.0 Authorization Endpoint
    /// </summary>
    [JsonPropertyName("authorization_endpoint")]
    [Required]
    [MinLength(0)]
    public required string AuthorizationEndpoint { get; init; }

    /// <summary>
    /// URL of the OAuth 2.0 Token Endpoint. This is REQUIRED unless only the Implicit Flow is used.
    /// </summary>
    [JsonPropertyName("token_endpoint")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? TokenEndpoint { get; init; } = null;
    
    /// <summary>
    /// URL of the JSON Web Key Set [JWK] document. This contains the signing key(s) the RP uses to validate signatures from the OP.
    /// </summary>
    [JsonPropertyName("jwks_uri")]
    [Required]
    [MinLength(0)]
    public required string JwksUri { get; init; }

    /// <summary>
    /// JSON array containing a list of the OAuth 2.0 [RFC6749] scope values that this server supports. The server MUST support the openid scope value.
    /// </summary>
    [JsonPropertyName("scopes_supported")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public ICollection<string> ScopesSupported { get; init; } = new List<string>(){"openid"};
    
    
    /// <summary>
    /// JSON array containing a list of the OAuth 2.0 response_type values that this OP supports. Dynamic OpenID Providers MUST support the code, id_token, and the token id_token Response Type values.
    /// </summary>
    [JsonPropertyName("response_types_supported")]
    [Required]
    public ICollection<string> ResponseTypesSupported { get; init; } = new List<string>(){"code","id_token","token id_token"};
    
    /// <summary>
    /// JSON array containing a list of the Subject Identifier types that this OP supports. Valid types include pairwise and public.
    /// </summary>
    [JsonPropertyName("subject_types_supported")]
    [Required]
    public ICollection<string> SubjectTypesSupported { get; init; } = new List<string>(){"pairwise","public"};
    
    /// <summary>
    /// JSON array containing a list of the JWS signing algorithms (alg values) supported by the OP for the ID Token to encode the Claims in a JWT. The algorithm RS256 MUST be included.
    /// </summary>
    [JsonPropertyName("id_token_signing_alg_values_supported")]
    [Required]
    public ICollection<string> IdTokenSigningAlgValuesSupported { get; init; } = new List<string>(){"RS256"};
    
    /// <summary>
    /// JSON array containing a list of the Claim Names of the Claims that the OpenID Provider MAY be able to supply values for. Note that for privacy or other reasons, this might not be an exhaustive list.
    /// </summary>
    [JsonPropertyName("claims_supported")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public ICollection<string> ClaimsSupported { get; init; } = new List<string>();
};