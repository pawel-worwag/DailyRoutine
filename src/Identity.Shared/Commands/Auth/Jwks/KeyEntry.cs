namespace Identity.Shared.Commands.Auth.Jwks;

/// <summary>
/// 
/// </summary>
public class KeyEntry
{
    /// <summary>
    /// The "kty" (key type) parameter identifies the cryptographic algorithm
    /// family used with the key, such as "RSA" or "EC".  "kty" values should
    /// either be registered in the IANA "JSON Web Key Types" registry
    /// established by [JWA] or be a value that contains a Collision-
    /// Resistant Name.  The "kty" value is a case-sensitive string.  
    /// This member MUST be present in a JWK.
    /// </summary>
    public string Kty { get; set; } = "RSA";
    /// <summary>
    /// The "alg" (algorithm) parameter identifies the algorithm intended for
    /// use with the key.  The values used should either be registered in the
    /// IANA "JSON Web Signature and Encryption Algorithms" registry
    /// established by [JWA] or be a value that contains a Collision-
    /// Resistant Name.  The "alg" value is a case-sensitive ASCII string.
    /// </summary>
    public string Alg { get; set; } = "RS256";
    /// <summary>
    /// The "kid" (key ID) parameter is used to match a specific key.  This
    /// is used, for instance, to choose among a set of keys within a JWK Set
    /// during key rollover.  The structure of the "kid" value is
    /// unspecified.  When "kid" values are used within a JWK Set, different
    /// keys within the JWK Set SHOULD use distinct "kid" values.
    /// </summary>
    public string Kid { get; set; } = "1";
    /// <summary>
    /// How the key was meant to be used. For the example, 'sig' represents signature verification.
    /// </summary>
    public string Use { get; set; } = "sig";
    /// <summary>
    /// The modulus for a standard pem.
    /// </summary>
    public string N { get; set; } = string.Empty;
    /// <summary>
    /// The exponent for a standard pem.
    /// </summary>
    public string E { get; set; } = string.Empty;
}