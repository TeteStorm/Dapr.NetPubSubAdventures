using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;
using Dapr;

var builder = WebApplication.CreateBuilder(args);

// Add dapr services to the container.
builder.Services.AddControllers().AddDapr();

var app = builder.Build();

// Dapr will send serialized event object vs. being raw CloudEvent
app.UseCloudEvents();

app.MapControllers();

// needed for Dapr pub/sub routing
app.MapSubscribeHandler();

app.Run();

