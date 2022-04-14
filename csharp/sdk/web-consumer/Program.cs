using System.Text.Json.Serialization;
using Dapr;

var builder = WebApplication.CreateBuilder(args);


// Add dapr services to the container registers the necessary services to integrate Dapr into the MVC pipeline. 
// It also registers a DaprClient instance into the dependency injection container, which then can be injected anywhere into your service.
builder.Services.AddControllers().AddDapr();

var app = builder.Build();

/* 
The call to UseCloudEvents adds CloudEvents middleware into to the ASP.NET Core middleware pipeline. 
This middleware will unwrap requests that use the CloudEvents structured format, so the receiving method can read the event payload directly.
The following example shows a CloudEvent serialized as JSON:
{
    "specversion" : "1.0",
    "type" : "com.github.pull_request.opened",
    "source" : "https://github.com/cloudevents/spec/pull",
    "subject" : "123",
    "id" : "A234-1234-1234",
    "time" : "2018-04-05T17:31:00Z",
    "comexampleextension1" : "value",
    "comexampleothervalue" : 5,
    "datacontenttype" : "text/xml",
    "data" : "<much wow=\"xml\"/>"
}
*/
app.UseCloudEvents();

// Needed for Dapr pub/sub routing
// The call to MapSubscribeHandler in the endpoint routing configuration will add a Dapr subscribe endpoint to the application. 
// This endpoint will respond to requests on /dapr/subscribe. 
// When this endpoint is called, it will automatically find all WebAPI action methods decorated with the 
// Topic attribute and instruct Dapr to create subscriptions for them.
app.MapSubscribeHandler();


// Dapr subscription in [Topic] routes events topic to this route
app.MapPost("/events", [Topic("new_pub_sub", "events")] (Event ev) => {
    Console.WriteLine("Subscriber received : " + ev);
    return Results.Ok(ev);
});

if (app.Environment.IsDevelopment()) {app.UseDeveloperExceptionPage();}

await app.RunAsync();

public record Event([property: JsonPropertyName("eventId")] int EventId);
