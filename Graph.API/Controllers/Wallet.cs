using System;
using Carter;
using Graph.API.Interface;
using Graph.API.Models;

namespace Graph.API.Controllers;

public class Wallet(IGraphClientIntegration graphClient): CarterModule(ApiVersion.ApiDefaultNameSpace + "/wallet_account")
{
  private readonly IGraphClientIntegration _graphClient =  graphClient;

    public override void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/fetch", async(string account_id) =>
        {
            var result = await _graphClient.FetchWalletAccount(account_id);
            return result is not null ? Results.Ok(result) : Results.BadRequest(result);    
        });

        app.MapGet("/list", async(int page = 1, int perPage = 20, string from = "2021-05-30", string to = "2099-05-30", string? currency = null, string? status = null) =>
        {
            var result = await _graphClient.ListAccount(page, perPage, from, to, currency, status);
            return result is not null ? Results.Ok(result) : Results.BadRequest(result);    
        });
    }
}
