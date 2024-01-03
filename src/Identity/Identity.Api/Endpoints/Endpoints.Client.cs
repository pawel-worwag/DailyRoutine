namespace Identity.Api.Endpoints;

public static partial class Endpoints
{
    private static RouteGroupBuilder AddClientEndpoints(this RouteGroupBuilder group)
    {
        group.MapGet("/", ()=>"clients")
            .WithName("get-clients")
            .WithSummary("Get registered clients").WithOpenApi()
            .DefaultProduces()
            .Produces(200,contentType:"application/json");
        
        group.MapPost("/", ()=>"clients")
            .WithName("add-client")
            .WithSummary("Add new api client").WithOpenApi()
            .DefaultProduces()
            .Produces(200,contentType:"application/json");
        
        group.MapGet("/{guid}", (Guid guid)=>"client")
            .WithName("get-client")
            .WithSummary("Get client details").WithOpenApi()
            .DefaultProduces()
            .Produces(200,contentType:"application/json");
        
        group.MapPut("/{guid}", (Guid guid)=>"client")
            .WithName("update-client")
            .WithSummary("Update api client").WithOpenApi()
            .DefaultProduces()
            .Produces(200,contentType:"application/json");
        
        group.MapDelete("/{guid}", (Guid guid)=>"client")
            .WithName("delete-client")
            .WithSummary("Delete api client").WithOpenApi()
            .DefaultProduces()
            .Produces(200,contentType:"application/json");
        
        
        return group;
    }
}