using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.WebUtilities;

namespace Identity.Api.Pages;

public partial class Login : ComponentBase
{
    [Inject] public NavigationManager NavManager { get; set; } = default;

    private string? Error = null;
    
    private string? ResponeType = null;
    private string? ClientId = null;
    private string? RedirectUri = null;
    private string? State = null;
    private string? Scope = null;
    
    protected override void OnInitialized()
    {
        var uri = NavManager.ToAbsoluteUri(NavManager.Uri);
        var queryStrings = QueryHelpers.ParseQuery(uri.Query);
        
        ResponeType = queryStrings.Where(p => p.Key == "response_type").Select(p=>p.Value).FirstOrDefault();
        ClientId = queryStrings.Where(p => p.Key == "client_id").Select(p=>p.Value).FirstOrDefault();
        RedirectUri = queryStrings.Where(p => p.Key == "redirect_uri").Select(p=>p.Value).FirstOrDefault();
        State = queryStrings.Where(p => p.Key == "state").Select(p=>p.Value).FirstOrDefault();
        Scope = queryStrings.Where(p => p.Key == "scope").Select(p=>p.Value).FirstOrDefault();

        if (string.IsNullOrWhiteSpace(ResponeType))
        {
            Error = $"Response type is null, empty or whitespace.";
            return;
        }
        if (ResponeType != "token")
        {
            Error = $"Unsupported response type - '{ResponeType}'.";
            return;
        }
    }

    private void SignIn()
    {
        string parameters = $"redirect_uri={RedirectUri}&token_type=Bearer";
        if (Scope is not null)
        {
            parameters += $"&scope={Scope}";
        }
        if (State is not null)
        {
            parameters += $"&state={State}";
        }

        //NavManager.NavigateTo($"/auth/redirect?{parameters}", forceLoad: true);
        parameters += "&access_token=cnreuybvejubveuvbuer&expires_in=3600";
        NavManager.NavigateTo($"{RedirectUri}?{parameters}", forceLoad: true);
    }
}