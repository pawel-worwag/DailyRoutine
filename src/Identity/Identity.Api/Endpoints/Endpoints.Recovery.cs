namespace Identity.Api.Endpoints;

public static partial class Endpoints
{
    private static RouteGroupBuilder AddRecoveryEndpoints(this RouteGroupBuilder group)
    {
        group.MapGet("/", ()=>"recovery")
            .WithName("get-recovery")
            .WithSummary("[TO-DO] Get list of password recovery requests (only metadata)").WithOpenApi()
            .DefaultProduces()
            .Produces(200,contentType:"application/json");
        
        group.MapPost("/", ()=>"recovery")
            .WithName("post-recovery")
            .WithSummary("[TO-DO] Create new recovery token / start password recovery procedure").WithOpenApi()
            .DefaultProduces()
            .Produces(200,contentType:"application/json");
        
        group.MapPost("/{guid}/complete", (Guid guid)=>"recovery")
            .WithName("post-recovery-complete")
            .WithSummary("[TO-DO] Finish password recovery procedure").WithOpenApi()
            .DefaultProduces()
            .Produces(200,contentType:"application/json");
        
        return group;
    }
}