namespace Identity.Api.Endpoints;

public static partial class Endpoints
{
    private static RouteGroupBuilder AddHelloEndpoints(this RouteGroupBuilder group)
    {
        group.MapGet("/", ()=>"hello")
            .WithName("get-hello")
            .WithSummary("Hello endpoint").WithOpenApi()
            .DefaultProduces()
            .Produces(200,contentType:"application/json");
        
        group.MapGet("/hc", ()=>"health")
            .WithName("get-health")
            .WithSummary("Health check").WithOpenApi()
            .DefaultProduces()
            .Produces(200,contentType:"application/json");
        
        return group;
    }
}