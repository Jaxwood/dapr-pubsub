using Microsoft.AspNetCore.Mvc;

var pubsubName = "pubsub";
var topicName = "greeting";
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDaprClient();

// Add services to the container.

var app = builder.Build();
app.UseCloudEvents();
app.MapSubscribeHandler();

// Configure the HTTP request pipeline.
app.MapPost("/greeter", ([FromBody] string message) =>
{
    app.Logger.LogInformation($"recieve message: {message}");
}).WithTopic(pubsubName, topicName);

app.Run();
