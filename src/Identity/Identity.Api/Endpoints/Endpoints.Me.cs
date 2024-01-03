namespace Identity.Api.Endpoints;

public static partial class Endpoints
{
    private static RouteGroupBuilder AddMeEndpoints(this RouteGroupBuilder group)
    {
        group.MapGet("/", ()=>"me")
            .WithName("get-me")
            .WithSummary("[TO-DO] Get my profile").WithOpenApi()
            .DefaultProduces()
            .Produces(200,contentType:"application/json");
        
        group.MapPut("/", ()=>"me")
            .WithName("put-me")
            .WithSummary("[TO-DO] Update my profile").WithOpenApi()
            .DefaultProduces()
            .Produces(200,contentType:"application/json");
        
        group.MapPut("/password", ()=>"password")
            .WithName("put-password")
            .WithSummary("[TO-DO] Update my password").WithOpenApi()
            .DefaultProduces()
            .Produces(200,contentType:"application/json");
        
        return group;
    }
}