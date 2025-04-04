using System;
using Carter;
using Graph.API.DataTransfers;
using Graph.API.Interface;
using Graph.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Graph.API.Controllers;

public class Payout(IGraphClientIntegration graphClient) :  CarterModule(ApiVersion.ApiDefaultNameSpace + "/payout")
{
    private readonly IGraphClientIntegration _graphClient = graphClient;

    public override void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/create", async ([FromBody] CreatePayoutRequest request) =>
        {
            var result = await _graphClient.CreatePayouts(request);
            return result is not null ? Results.Ok(result) : Results.BadRequest(result);    
        });

        app.MapGet("/fetch", async (string payout_id) =>
        {
            var result = await _graphClient.FetchPayouts(payout_id);
            return result is not null ? Results.Ok(result) : Results.BadRequest(result);    
        });

         app.MapGet("/list", async (int pageNum, int pageSize) =>
        {
            var result = await _graphClient.ListPayouts(pageNum, pageSize);
            return result is not null ? Results.Ok(result) : Results.BadRequest(result);    
        });
    }
}
