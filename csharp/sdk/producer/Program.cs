using System;
using Dapr.Client;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

for (int i = 1; i <= 10; i++) {
    var ev = new Event(i);
    using var client = new DaprClientBuilder().Build();

    // Publish an event/message using Dapr PubSub
    await client.PublishEventAsync("new_pub_sub", "events", ev);
    Console.WriteLine("Published data: " + ev);

    await Task.Delay(TimeSpan.FromSeconds(1));
}

public record Event([property: JsonPropertyName("eventId")] int EventId);
