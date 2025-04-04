using System;
using Carter;
using Graph.API.DataTransfers;
using Graph.API.Interface;
using Graph.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Graph.API.Controllers;

public class Deposit(IGraphClientIntegration graphClient) :  CarterModule(ApiVersion.ApiDefaultNameSpace + "/deposit")
{
   private readonly IGraphClientIntegration _graphClient = graphClient;

    public override void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/fetch", async(string deposit_id) =>
        {
            var result = await _graphClient.FetchDeposit(deposit_id);
            return result is not null ? Results.Ok(result) : Results.BadRequest(result);    
        });

         app.MapGet("/list", async(int pageNum, int pageSize) =>
        {
            var result = await _graphClient.ListDeposits(pageNum, pageSize);
            return result is not null ? Results.Ok(result) : Results.BadRequest(result);    
        });

        app.MapGet("/deposit", async([FromBody] DepositRequest request) =>
        {
            var result = await _graphClient.Deposit(request);
            return result is not null ? Results.Ok(result) : Results.BadRequest(result);    
        });

    }
}
