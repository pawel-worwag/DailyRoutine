namespace Identity.Api.Endpoints;

public static partial class Endpoints
{
    public static WebApplication MapIdentityEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("/api/identity-management/");
        group.WithTags(["Hello"]);
        group.AddHelloEndpoints();
        
        group = app.MapGroup("/api/identity-management/");
        group.WithTags(["Auth"]);
        group.AddAuthEndpoints();
        
        group = app.MapGroup("/api/identity-management/clients/");
        group.WithTags(["Client"]);
        group.AddClientEndpoints();
        
        group = app.MapGroup("/api/identity-management/me");
        group.WithTags(["Me"]);
        group.AddMeEndpoints();
        
        group = app.MapGroup("/api/identity-management/recovery-password-tokens");
        group.WithTags(["Recovery"]);
        group.AddRecoveryEndpoints();
        
        group = app.MapGroup("/api/identity-management/registration-tokens");
        group.WithTags(["Registration"]);
        group.AddRegistrationEndpoints();
        
        group = app.MapGroup("/api/identity-management/roles");
        group.WithTags(["Roles"]);
        group.AddRolesEndpoints();
        
        group = app.MapGroup("/api/identity-management/users");
        group.WithTags(["Users"]);
        group.AddUsersEndpoints();
        
        
        app.MapGet("/auth/redirect",  async (context) =>
        {
            await Task.CompletedTask;
            var url = context.Request.Query["url"];

            if (string.IsNullOrWhiteSpace(url))
            {
                context.Response.StatusCode = 400;

            }
            else
            {
                Console.WriteLine($"url = {url}");
                context.Response.StatusCode = 302;
                context.Response.Redirect(url);
            }
        }).WithName("auth-redirect").WithOpenApi();
        
        return app;
    }
    
    private static RouteHandlerBuilder DefaultProduces(this RouteHandlerBuilder builder)
    {
        builder.Produces(500, typeof(Common.Exceptions.ErrorResponse),"application/json");
        return builder;
    }
}