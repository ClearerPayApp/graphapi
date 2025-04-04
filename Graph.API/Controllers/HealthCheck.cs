using Carter;
using Graph.API.Interface;
using Graph.API.Models;

namespace Graph.API.Controllers;

public class HealthCheck(IGraphClientIntegration graphClient) : CarterModule(ApiVersion.ApiDefaultNameSpace + "/health")
{
    private readonly IGraphClientIntegration _graphClient = graphClient;

    public override void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("get", async () =>
        {
            var result = await _graphClient.HealthChecks();
            return result is not null ? Results.Ok(result) : Results.BadRequest();    
        });
    }
}
