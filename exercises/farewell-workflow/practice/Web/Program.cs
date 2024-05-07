using Temporalio.Client;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Temporalio.Farewell.Workflow;

//   call this via HTTP GET with a URL like:
//   http://localhost:5125/get-spanish-farewell?name=Temporal
//   http://localhost:5125/get-spanish-farewell?name=Temporal

// Setup the ASP.NET Core application
var builder = WebApplication.CreateBuilder(args);

// Console logging
builder.Logging.AddSimpleConsole().SetMinimumLevel(LogLevel.Information);

var app = builder.Build();

// HTTP Endpoint for Spanish Greeting
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

// HTTP Endpoint for Spanish Farewell
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

app.Run();  // Start the web server

