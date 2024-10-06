using Ordering.API;
using Ordering.Applicaion;
using Ordering.Infrastruture;

var builder = WebApplication.CreateBuilder(args);

// Add Services to the container

builder.Services
    .AddApplicationServices()
    .AddInfrastructureServices(builder.Configuration)
    .AddApiServices();
// configure HTTP Request pipeline



var app = builder.Build();


app.Run();
