using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

var builder = WebApplication.CreateBuilder(args);

builder.Logging.AddSimpleConsole().SetMinimumLevel(LogLevel.Information);

var app = builder.Build();

app.MapGet("/get-spanish-greeting", (HttpContext context) =>
{
    var query = context.Request.Query["name"];
    if (query.Count > 0)
    {
        var name = query[0];
        var greeting = $"¡Hola, {name}!";
        Console.WriteLine(greeting);  // Output greeting in terminal
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
        Console.WriteLine(farewell);  // Output farewell in terminal
        return Results.Ok(farewell);  // Return HTTP response with farewell
    }
    else
    {
        return Results.BadRequest("Missing required 'name' parameter.");
    }
});

app.Run();

