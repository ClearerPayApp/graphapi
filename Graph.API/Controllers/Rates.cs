using System;
using Carter;
using Graph.API.Interface;
using Graph.API.Models;

namespace Graph.API.Controllers;

public class Rates(IGraphClientIntegration graphClient) : CarterModule(ApiVersion.ApiDefaultNameSpace + "/rates")
{
    private readonly IGraphClientIntegration _graphClient = graphClient;
    public override void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/fetch", async() =>
        {
            var result = await _graphClient.FetchRates();
            return result is not null ? Results.Ok(result) : Results.BadRequest(result);    
        });
    }
}
