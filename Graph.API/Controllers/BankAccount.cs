using System;
using Carter;
using Graph.API.DataTransfers;
using Graph.API.Interface;
using Graph.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Graph.API.Controllers;

public class BankAccount(IGraphClientIntegration graphClient) : CarterModule(ApiVersion.ApiDefaultNameSpace + "/bank_account")
{
    private readonly IGraphClientIntegration _graphClient = graphClient;
    public override void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/create", async([FromBody] CreateAccountRequest request) =>
        {
            var result = await _graphClient.CreateAccount(request);
            return result is not null ? Results.Ok(result) : Results.BadRequest(result);    
        });

        app.MapGet("/fetch", async(string account_id) =>
        {
            var result = await _graphClient.FetchAccount(account_id);
            return result is not null ? Results.Ok(result) : Results.BadRequest(result);    
        });

         app.MapPatch("/update-account-status", async(string account_id, [FromBody] UpdateAccountRequest request) =>
        {
            var result = await _graphClient.UpdateAccountStatus(account_id, request);
            return result is not null ? Results.Ok(result) : Results.BadRequest(result);    
        });

        app.MapGet("/list", async([FromBody] ListAccountsRequest request) =>
        {
            var result = await _graphClient.ListAccount(request);
            return result is not null ? Results.Ok(result) : Results.BadRequest(result);    
        });


        app.MapPost("/add-whitelist", async(string account_id, [FromBody] WhitelistAccountRequest request) =>
        {
            var result = await _graphClient.AddWhitelistAccount(account_id, request);
            return result is not null ? Results.Ok(result) : Results.BadRequest(result);    
        });

        app.MapGet("/list-whitelist", async(string account_id, int page, int perPage) =>
        {
            var result = await _graphClient.ListWhitelistAccounts(account_id, page, perPage);
            return result is not null ? Results.Ok(result) : Results.BadRequest(result);    
        });

        app.MapDelete("/remove-whitelist", async(string account_id,  string item_id) =>
        {
            var result = await _graphClient.RemoveWhitelistAccount(account_id, item_id);
            return result is not null ? Results.Ok(result) : Results.BadRequest(result);    
        });

          app.MapDelete("/clear-whitelist", async(string account_id) =>
        {
            var result = await _graphClient.ClearWhitelistAccounts(account_id);
            return result is not null ? Results.Ok(result) : Results.BadRequest(result);    
        });


    }
}
