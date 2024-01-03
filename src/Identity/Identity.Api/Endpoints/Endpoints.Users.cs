namespace Identity.Api.Endpoints;

public static partial class Endpoints
{
    private static RouteGroupBuilder AddUsersEndpoints(this RouteGroupBuilder group)
    {
        group.MapGet("/", ()=>"users")
            .WithName("get-users")
            .WithSummary("Get list of registered users").WithOpenApi()
            .DefaultProduces()
            .Produces(200,contentType:"application/json");
        
        group.MapPost("/", ()=>"user")
            .WithName("post-user")
            .WithSummary("Add new user").WithOpenApi()
            .DefaultProduces()
            .Produces(200,contentType:"application/json");
        
        group.MapGet("/{guid}", (Guid guid)=>"user")
            .WithName("get-user")
            .WithSummary("Get user details").WithOpenApi()
            .DefaultProduces()
            .Produces(200,contentType:"application/json");
        
        group.MapPut("/{guid}", (Guid guid)=>"user")
            .WithName("put-user")
            .WithSummary("Update user data").WithOpenApi()
            .DefaultProduces()
            .Produces(200,contentType:"application/json");
        
        group.MapDelete("/{guid}/recovery-tokens", (Guid guid)=>"user")
            .WithName("delete-user-recovery-tokens")
            .WithSummary("Reject all recovery tokens").WithOpenApi()
            .DefaultProduces()
            .Produces(200,contentType:"application/json");
        
        group.MapPost("/{guid}/send-welcome-email", (Guid guid)=>"user")
            .WithName("send-welcome-email")
            .WithSummary("[TO-DO] Send Welcome-Email to user").WithOpenApi()
            .DefaultProduces()
            .Produces(200,contentType:"application/json");
        
        return group;
    } 
}