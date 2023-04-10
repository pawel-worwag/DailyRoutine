using System.Text.Json.Serialization;

namespace Identity.Shared.Commands.Auth.OpenIdConfiguration;

public class OpenIdConfigurationResponse
{
    /// <summary>
    /// REQUIRED. URL using the https scheme with no query or fragment
    /// component that the OP asserts as its Issuer Identifier.
    /// If Issuer discovery is supported (see Section 2),
    /// this value MUST be identical to the issuer value returned
    /// by WebFinger. This also MUST be identical to the iss Claim
    /// value in ID Tokens issued from this Issuer.
    /// </summary>
    [JsonPropertyName("issuer")]
    public string Issuer { get; set; } = string.Empty;
    
    /// <summary>
    /// REQUIRED. URL of the OP's JSON Web Key Set [JWK] document.
    /// This contains the signing key(s) the RP uses to validate
    /// signatures from the OP. The JWK Set MAY also contain
    /// the Server's encryption key(s), which are used by RPs
    /// to encrypt requests to the Server. When both signing
    /// and encryption keys are made available, a use (Key Use)
    /// parameter value is REQUIRED for all keys in the
    /// referenced JWK Set to indicate each key's intended usage.
    /// Although some algorithms allow the same key to be used
    /// for both signatures and encryption, doing so is NOT RECOMMENDED,
    /// as it is less secure. The JWK x5c parameter MAY be used
    /// to provide X.509 representations of keys provided.
    /// When used, the bare key values MUST still be present
    /// and MUST match those in the certificate.
    /// </summary>
    [JsonPropertyName("jwks_uri")]
    public string JwksUri { get; set; } = string.Empty;
    
    /// <summary>
    /// REQUIRED. URL of the OP's OAuth 2.0 Authorization Endpoint [OpenID.Core].
    /// </summary>
    [JsonPropertyName("authorization_endpoint")]
    public string AuthorizationEndpoint { get; set; } = string.Empty;
    
    /// <summary>
    /// URL of the OP's OAuth 2.0 Token Endpoint [OpenID.Core].
    /// This is REQUIRED unless only the Implicit Flow is used.
    /// </summary>
    [JsonPropertyName("token_endpoint")]
    public string TokenEndpoint { get; set; } = string.Empty;
    
    /// <summary>
    /// RECOMMENDED. JSON array containing a list of the OAuth 2.0 [RFC6749]
    /// scope values that this server supports. The server MUST support
    /// the openid scope value. Servers MAY choose not to advertise
    /// some supported scope values even when this parameter is used,
    /// although those defined in [OpenID.Core] SHOULD be listed, if supported.
    /// </summary>
    [JsonPropertyName("scopes_supported")]
    public List<string>? ScopesSupported { get; set; } = new List<string>();
    
    /// <summary>
    /// REQUIRED. JSON array containing a list of the OAuth 2.0 response_type
    /// values that this OP supports. Dynamic OpenID Providers MUST support
    /// the code, id_token, and the token id_token Response Type values.
    /// </summary>
    [JsonPropertyName("response_types_supported")]
    public List<string> ResponseTypesSupported { get; set; } = new List<string>();
    
    /// <summary>
    /// REQUIRED. JSON array containing a list of the Subject Identifier
    /// types that this OP supports. Valid types include pairwise and public.
    /// </summary>
    [JsonPropertyName("subject_types_supported")]
    public List<string> SubjectTypesSupported { get; set; } = new List<string>();
    
    /// <summary>
    /// REQUIRED. JSON array containing a list of the JWS signing algorithms
    /// (alg values) supported by the OP for the ID Token to encode the Claims
    /// in a JWT [JWT]. The algorithm RS256 MUST be included. The value none
    /// MAY be supported, but MUST NOT be used unless the Response Type used
    /// returns no ID Token from the Authorization Endpoint
    /// (such as when using the Authorization Code Flow).
    /// </summary>
    [JsonPropertyName("id_token_signing_alg_values_supported")]
    public List<string> IdTokenSigningAlgValuesSupported { get; set; } = new List<string>();
}