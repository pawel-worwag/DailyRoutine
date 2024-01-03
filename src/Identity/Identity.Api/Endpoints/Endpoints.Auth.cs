
namespace Identity.Api.Endpoints;

public static partial class Endpoints
{
    private static RouteGroupBuilder AddAuthEndpoints(this RouteGroupBuilder group)
    {
        group.MapGet("/openid-configuration", ()=>"openid-configuration")
            .WithName("openid-configuration")
            .WithSummary("Server discovery endpoint").WithOpenApi()
            .DefaultProduces()
            .Produces(200,contentType:"application/json");
        
        group.MapGet("/jwks", ()=>"jwks")
            .WithName("jwks")
            .WithSummary("Get JSON Web Keys set").WithOpenApi()
            .DefaultProduces()
            .Produces(200,contentType:"application/json");

        group.MapPost("/tokens", ()=>"tokens")
            .WithName("tokens")
            .WithSummary("[TO-DO] Create a new tokens with claims").WithOpenApi()
            .DefaultProduces()
            .Produces(200,contentType:"application/json");

        
        
        return group;
    }
}