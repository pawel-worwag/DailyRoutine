namespace Identity.Api.Endpoints;

public static partial class Endpoints
{
    private static RouteGroupBuilder AddRegistrationEndpoints(this RouteGroupBuilder group)
    {
        group.MapGet("/", ()=>"registrations")
            .WithName("get-registrations")
            .WithSummary("[TO-DO] Get list of user registrations in progress").WithOpenApi()
            .DefaultProduces()
            .Produces(200,contentType:"application/json");
        
        group.MapPost("/", ()=>"registrations")
            .WithName("post-registrations")
            .WithSummary("[TO-DO] Start new user registration procedure").WithOpenApi()
            .DefaultProduces()
            .Produces(200,contentType:"application/json");
        
        group.MapPost("/{guid}", (Guid guid)=>"registrations")
            .WithName("post-registrations-complete")
            .WithSummary("[TO-DO] Finish new user registration").WithOpenApi()
            .DefaultProduces()
            .Produces(200,contentType:"application/json");
        
        return group;
    }
}