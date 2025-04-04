using Carter;
using Graph.API.DataTransfers;
using Graph.API.Interface;
using Graph.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Graph.API.Controllers
{
 
    public class Business(IGraphClientIntegration graphClient) : CarterModule(ApiVersion.ApiDefaultNameSpace + "/business")
    {
        private readonly IGraphClientIntegration _graphClient = graphClient;

        public override void AddRoutes(IEndpointRouteBuilder app)
        {
             app.MapPost("/create", async([FromBody] CreateBusinessRequest request) =>
            {
                var result = await _graphClient.CreateBusiness(request);
                return result is not null ? Results.Ok(result) : Results.BadRequest(result);    
            });
            

            app.MapGet("/fetch", async(string business_id) =>
            {
                var result = await _graphClient.FetchBusiness(business_id);
                return result is not null ? Results.Ok(result) : Results.BadRequest(result);    
            });

            app.MapGet("/list", async(int pageNum, int pageSize) =>
            {
                var result = await _graphClient.ListBusinesses(pageNum, pageSize);
                return result is not null ? Results.Ok(result) : Results.BadRequest(result);    
            });
        }
    }
}
