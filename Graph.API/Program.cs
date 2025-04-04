using Carter;
using Graph.API.Integrations;
using Graph.API.Interface;
using Graph.API.Models;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi

builder.Services.Configure<GraphSettings>(builder.Configuration.GetSection("GraphSettings"));
builder.Services.AddHttpClient<IGraphClientIntegration, GraphClientIntegration>();
builder.Services.AddEndpointsApiExplorer(); // Add this
// builder.Services.AddOpenApi("/swagger");
builder.Services.AddCarter();
builder.Services.AddSwaggerGen(c => {
     c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Clearer.Graph",
        Version = "v1",
        Description = "Backend APIs to manage Graph Services",
        Contact = new OpenApiContact
        {
            Name = "Graph",
            Email = "graph@gmail.com"
        }
    });
});

// CORS Configuration
builder.Services.AddCors(c =>
{
    c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin());
});

var app = builder.Build();

// Configure the HTTP request pipeline.

    // app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();


app.UseHttpsRedirection();
app.UseRouting();

app.MapCarter();

app.UseCors("AllowOrigin");


app.Run();

