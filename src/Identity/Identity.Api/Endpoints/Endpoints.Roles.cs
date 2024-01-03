namespace Identity.Api.Endpoints;

public static partial class Endpoints
{
    private static RouteGroupBuilder AddRolesEndpoints(this RouteGroupBuilder group)
    {
        group.MapGet("/", ()=>"roles")
            .WithName("get-roles")
            .WithSummary("Get list of allowed roles").WithOpenApi()
            .DefaultProduces()
            .Produces(200,contentType:"application/json");
        
        return group;
    }
}