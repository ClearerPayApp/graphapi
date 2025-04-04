using System;
using Carter;
using Graph.API.Interface;
using Graph.API.Models;

namespace Graph.API.Controllers;

public class Transaction(IGraphClientIntegration graphClient) : CarterModule(ApiVersion.ApiDefaultNameSpace + "/transaction")
{
  private readonly IGraphClientIntegration _graphClient = graphClient;

    public override void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/fetch", async(string transaction_id) =>
        {
            var result = await _graphClient.FetchTransactions(transaction_id);
            return result is not null ? Results.Ok(result) : Results.BadRequest(result);    
        });

         app.MapGet("/list", async(int page = 1, int perPage = 20, string from = "", string to = "", string status = "", string currency = "", string accountId = "", string cardId = "", string linkedTransactionId = "", bool asc = false) =>
        {
            var result = await _graphClient.ListTransactions(page, perPage, from, to, status, currency, accountId, cardId, linkedTransactionId, asc);
            return result is not null ? Results.Ok(result) : Results.BadRequest(result);    
        });
    }
}
