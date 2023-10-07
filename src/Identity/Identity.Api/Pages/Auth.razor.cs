using Identity.Api.Models.Auth;
using MediatR;
using Microsoft.AspNetCore.Components;

namespace Identity.Api.Pages;

/// <summary>
/// 
/// </summary>
public partial class Auth : ComponentBase
{
    [Inject]
    private NavigationManager Navigation { get; set; } = default!;
    
    [Inject] 
    private IMediator Mediator { get; set; } = default!;

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
    
    private Models.Auth.AuthorizationRequest? _request;

    private string? _error = null;
    
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    protected override async Task OnInitializedAsync()
    {
        _request = new AuthorizationRequest()
        {
            ResponseType = ResponseType??"",
            ClientId = ClientId??"",
            Scope = Scope,
            State = State,
            RedirectUri = RedirectUri,
            Nonce = Nonce
        };
        try
        {
            await Mediator.Send(new Application.Auth.AuthorizationValidate.AuthorizationValidateRequest()
            {
                ResponseType = ResponseType,
                ClientId = ClientId,
                Scope = Scope,
                State = State,
                RedirectUri = RedirectUri
            });
        }
        catch (Exception ex)
        {
            _error = ex.Message;
        }
        await base.OnInitializedAsync(); 
    }

    private void OnLoginClick()
    {
        var redirectUrl = $"{_request.RedirectUri}?";
        if (_request.State is not null)
        {
            redirectUrl += $"&state={_request.State}";
        }
        if (_request.Nonce is not null)
        {
            redirectUrl += $"&nonce={_request.Nonce}";
        }

        redirectUrl += "&access_token=cervcrsc";
        redirectUrl += "&id_token=cedswdrvcrsc";
        redirectUrl += "&token_type=Bearer";
        redirectUrl += "&expires_in=3600";
        var param = Uri.EscapeDataString(redirectUrl);
        
        Console.WriteLine($"pip: /auth/redirect?url={param}");
        Navigation.NavigateTo($"/auth/redirect?url={param}",forceLoad: true,replace:true);
    }
}