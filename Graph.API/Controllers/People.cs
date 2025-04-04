using Carter;
using Graph.API.DataTransfers;
using Graph.API.Interface;
using Graph.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Graph.API.Controllers;

public class People(IGraphClientIntegration graphClient) : CarterModule(ApiVersion.ApiDefaultNameSpace + "/people")
{
   private readonly IGraphClientIntegration _graphClient = graphClient;

    public override void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/create", async([FromBody] CreatePersonRequest request) =>
        {
            var result = await _graphClient.CreatePerson(request);
            return result is not null ? Results.Ok(result) : Results.BadRequest();    
        });

        app.MapGet("/fetch-person", async (string person_id) =>
        {
            var result = await _graphClient.FetchPerson(person_id);
            return result is not null ? Results.Ok(result) : Results.BadRequest();    
        });

        app.MapGet("/list-people", async () =>
        {
            var result = await _graphClient.ListPeople();
            return result is not null ? Results.Ok(result) : Results.BadRequest();    
        });

        app.MapPatch("/update-kyc", async ([FromBody] UpdatePersonKycRequest request) =>
        {
            var result = await _graphClient.UpgradePersonKYC(request);
            return result is not null ? Results.Ok(result) : Results.BadRequest(result);    
        });

         app.MapPatch("/update-person", async (string person_id, [FromBody] UpdatePersonRequest request) =>
        {
            var result = await _graphClient.UpdatePerson(person_id, request);
            return result is not null ? Results.Ok(result) : Results.BadRequest(result);    
        });
    }
}
