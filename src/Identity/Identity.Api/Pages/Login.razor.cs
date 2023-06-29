using MediatR;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.WebUtilities;

namespace Identity.Api.Pages;

public partial class Login : ComponentBase
{

    [Inject] public NavigationManager NavManager { get; set; } = default;
    [Inject] public IServiceScopeFactory ScopeFactory { get; set; } = default;

    private bool Loading = true;
    private string? Error = null;
    private string? Warning = null;
    
    private string? ResponeType = null;
    private string? ClientId = null;
    private string? RedirectUri = null;
    private string? State = null;
    private string? Scope = null;
    
    private string Email = string.Empty;
    private string Password = string.Empty;
    
    protected override async void OnInitialized()
    {
        var uri = NavManager.ToAbsoluteUri(NavManager.Uri);
        Console.WriteLine(uri);
        
        ParseQuery(uri.Query);
        await ValidRequest();
        Loading = false;
        StateHasChanged();
    }

    private void SignIn()
    {
        if (string.IsNullOrWhiteSpace(Email))
        {
            Warning = "Email is empty.";
            StateHasChanged();
            return;
        }
        if (string.IsNullOrWhiteSpace(Password))
        {
            Warning = "Password is empty.";
            StateHasChanged();
            return;
        }
        RedirectToFallback();
    }

    private void RedirectToFallback()
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
        Console.WriteLine($"Redirect to: {RedirectUri}?{parameters}");
        NavManager.NavigateTo($"{RedirectUri}?{parameters}", forceLoad: true);
    }
    
    private void ParseQuery(string query)
    {
        var queryStrings = QueryHelpers.ParseQuery(query);
        ResponeType = queryStrings.Where(p => p.Key == "response_type").Select(p=>p.Value).FirstOrDefault();
        ClientId = queryStrings.Where(p => p.Key == "client_id").Select(p=>p.Value).FirstOrDefault();
        RedirectUri = queryStrings.Where(p => p.Key == "redirect_uri").Select(p=>p.Value).FirstOrDefault();
        State = queryStrings.Where(p => p.Key == "state").Select(p=>p.Value).FirstOrDefault();
        Scope = queryStrings.Where(p => p.Key == "scope").Select(p=>p.Value).FirstOrDefault();
    }

    private async Task ValidRequest()
    {
        try
        {
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

            using var scope = ScopeFactory.CreateScope();
            var mediator = scope.ServiceProvider.GetRequiredService<IMediator>();
            var result = await mediator.Send(new Application.Auth.Clients.VerifyClient.VerifyClientRequest()
            {
                ClientId = Guid.Parse(ClientId),
                RedirectUri = RedirectUri
            });

            if (!result.IsValid)
            {
                Error = result.Error;
                return;
            }
        }
        catch (Exception ex)
        {
            Error = "Exception: " + ex.Message;
        }
    }
}