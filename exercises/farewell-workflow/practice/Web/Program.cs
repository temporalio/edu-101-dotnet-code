using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

var builder = WebApplication.CreateBuilder(args);
builder.Logging.AddSimpleConsole().SetMinimumLevel(LogLevel.Information);
var logger = builder.Logging.CreateLogger("SpanishGreetingApp");

var app = builder.Build();

app.MapGet("/get-spanish-greeting", (HttpContext context) =>
{
    var query = context.Request.Query["name"];
    if (query.Count > 0)
    {
        var name = query[0];
        var greeting = $"¡Hola, {name}!";
        logger.LogInformation($"Returning Spanish greeting: {greeting}");
        return Results.Ok(greeting);  // Return HTTP response with greeting
    }
    else
    {
        return Results.BadRequest("Missing required 'name' parameter.");
    }
});

app.MapGet("/get-spanish-farewell", (HttpContext context) =>
{
    var query = context.Request.Query["name"];
    if (query.Count > 0)
    {
        var name = query[0];
        var farewell = $"¡Adiós, {name}!";
        logger.LogInformation($"Returning Spanish farewell: {farewell}");
        return Results.Ok(farewell);  // Return HTTP response with farewell
    }
    else
    {
        return Results.BadRequest("Missing required 'name' parameter.");
    }
});

app.Run();
