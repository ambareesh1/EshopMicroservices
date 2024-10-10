using Ordering.API;
using Ordering.Applicaion;
using Ordering.Infrastruture;
using Ordering.Infrastruture.Data.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add Services to the container

builder.Services
    .AddApplicationServices()
    .AddInfrastructureServices(builder.Configuration)
    .AddApiServices();

// configure HTTP Request pipeline
var app = builder.Build();

app.useApiServices();

if (app.Environment.IsDevelopment())
{
    await app.InitialiseDatabaseAsync();
}

app.Run();
