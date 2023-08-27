namespace Identity.Api.Models.Clients;

/// <summary>
/// 
/// </summary>
public record UpdateClientDto
{
    /// <summary>
    /// 
    /// </summary>
    public required string Name { get; init; }
    /// <summary>
    /// 
    /// </summary>
    public required ICollection<string> Endpoints { get; init; }
}