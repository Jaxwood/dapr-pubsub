using Dapr.Client;

var pubsubName = "pubsub";
var topicName = "greeting";
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDaprClient();

// Add services to the container.

var app = builder.Build();
app.UseCloudEvents();
app.MapSubscribeHandler();

// Configure the HTTP request pipeline.
app.MapGet("/saysomething/{message}", async (string message, DaprClient client) =>
{
    await client.PublishEventAsync(pubsubName, topicName, message);
    app.Logger.LogInformation($"send message {message} to topic {topicName}");
});

app.Run();