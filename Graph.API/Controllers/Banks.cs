using System;
using Carter;
using Graph.API.DataTransfers;
using Graph.API.Interface;
using Graph.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Graph.API.Controllers;

public class Banks(IGraphClientIntegration graphClient) : CarterModule(ApiVersion.ApiDefaultNameSpace + "/banks")
{
    private readonly IGraphClientIntegration _graphClient = graphClient;
    public override void AddRoutes(IEndpointRouteBuilder app)
    {
       app.MapGet("/list", async (string payout_id) =>
       {
           var result = await _graphClient.FetchPayouts(payout_id);
           return result is not null ? Results.Ok(result) : Results.BadRequest(result);
       });

       app.MapPost("/resolve-bank-account", async ([FromBody] ResolveBankAccountRequest request) =>
       {
           var result = await _graphClient.ResolveBankAccount(request);
           return result is not null ? Results.Ok(result) : Results.BadRequest(result);
       });
    }
}
