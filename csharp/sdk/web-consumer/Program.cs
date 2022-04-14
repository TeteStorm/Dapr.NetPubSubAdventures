using System.Text.Json.Serialization;
using Dapr;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

// Dapr will send serialized event object vs. being raw CloudEvent
app.UseCloudEvents();

// needed for Dapr pub/sub routing
app.MapSubscribeHandler();

if (app.Environment.IsDevelopment()) {app.UseDeveloperExceptionPage();}

// Dapr subscription in [Topic] routes events topic to this route
app.MapPost("/events", [Topic("new_pub_sub", "events")] (Event ev) => {
    Console.WriteLine("Subscriber received : " + ev);
    return Results.Ok(ev);
});

await app.RunAsync();

public record Event([property: JsonPropertyName("eventId")] int EventId);
