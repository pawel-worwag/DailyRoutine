using Identity.Api.Models.Auth;
using MediatR;
using Microsoft.AspNetCore.Components;

namespace Identity.Api.Pages;

/// <summary>
/// 
/// </summary>
public partial class Auth : ComponentBase
{
    [Inject] private NavigationManager Navigation { get; set; } = default!;

    [Inject] private IMediator Mediator { get; set; } = default!;

    private string UserName { get; set; } = string.Empty;
    private string Password { get; set; } = string.Empty;

    private ICollection<string> _requestValidationError = new List<string>();
    private ICollection<string> _requestHandlingError = new List<string>();


    /// <summary/>
    protected override async Task OnInitializedAsync()
    {
        var validation = await Mediator.Send(new Application.Auth.AuthorizationValidate.AuthorizationValidateRequest()
        {
            ResponseType = ResponseType,
            ClientId = (ClientId is null) ? null : new Guid(ClientId),
            RedirectUri = RedirectUri,
            Scope = Scope,
            State = State
        });

        _requestValidationError = validation.Errors;

        await base.OnInitializedAsync();
    }

    private async void OnLoginClick()
    {
            var redirectUrl = await Mediator.Send(new Application.Auth.GetAuthorization.GetAuthorizationRequest()
            {
                ResponseType = ResponseType,
                ClientId = (ClientId is null) ? null : new Guid(ClientId),
                RedirectUri = RedirectUri,
                Scope = Scope,
                State = State
            });
            var param = Uri.EscapeDataString(redirectUrl);

            Console.WriteLine($"pip: /auth/redirect?url={param}");
            Navigation.NavigateTo($"/auth/redirect?url={param}", forceLoad: true, replace: true);
    }
}