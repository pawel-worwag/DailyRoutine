using Microsoft.AspNetCore.Components;

namespace Identity.Api.Pages;

public partial class Auth : ComponentBase
{
    /// <summary>
    /// 
    /// </summary>
    [Parameter]
    [SupplyParameterFromQuery(Name = "response_type")]
    public string? ResponseType { get; init; }

    /// <summary>
    /// 
    /// </summary>
    [Parameter]
    [SupplyParameterFromQuery(Name = "client_id")]
    public string? ClientId { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [Parameter]
    [SupplyParameterFromQuery(Name = "scope")]
    public string? Scope { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [Parameter]
    [SupplyParameterFromQuery(Name = "state")]
    public string? State { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [Parameter]
    [SupplyParameterFromQuery(Name = "redirect_uri")]
    public string? RedirectUri { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [Parameter]
    [SupplyParameterFromQuery(Name = "nonce")]
    public string? Nonce { get; set; }
}