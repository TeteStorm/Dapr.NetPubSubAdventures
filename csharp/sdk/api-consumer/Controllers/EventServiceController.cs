using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System;
using Microsoft.AspNetCore.Mvc;
using Dapr;
using Dapr.Client;


namespace api_consumer.Controllers;

[ApiController]
[Route("[controller]")]
 public class EventServiceController : Controller
 {
    //Subscribe to a topic 
    [Topic("new_pub_sub", "events")]
    [HttpPost("/events")]
    public ActionResult GetEvents(Event requestData)
    {
        Console.WriteLine("Subscriber received : " + requestData);
         return Ok("Event Received");
    }
}
public record Event([property: JsonPropertyName("eventId")] int EventId);


