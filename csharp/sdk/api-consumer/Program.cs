using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;
using Dapr;

var builder = WebApplication.CreateBuilder(args);

// Add dapr services to the container registers the necessary services to integrate Dapr into the MVC pipeline. 
// It also registers a DaprClient instance into the dependency injection container, which then can be injected anywhere into your service.
builder.Services.AddControllers().AddDapr();

var app = builder.Build();

// Dapr will send serialized event object unwrapped by CloudEvents middleware vs. being raw CloudEvent
app.UseCloudEvents();

app.MapControllers();

// Needed for Dapr pub/sub routing
app.MapSubscribeHandler();

app.Run();

