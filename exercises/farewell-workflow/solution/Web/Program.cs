using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

var builder = WebApplication.CreateBuilder(args);

builder.Logging.ClearProviders();
builder.Logging.AddSimpleConsole(options =>
{
    options.IncludeScopes = true;
    options.SingleLine = true;
    options.TimestampFormat = "hh:mm:ss ";
}).SetMinimumLevel(LogLevel.Information);

var app = builder.Build();

var logger = app.Services.GetRequiredService<ILogger<Program>>();

app.MapGet("/get-spanish-greeting", (HttpContext context) =>
{
    var query = context.Request.Query["name"];
    if (query.Count > 0)
    {
        var name = query[0];
        var greeting = $"¡Hola, {name}!";
        logger.LogInformation($"Returning Spanish greeting: {greeting}");
        return Results.Ok(greeting);
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
        return Results.Ok(farewell);
    }
    else
    {
        return Results.BadRequest("Missing required 'name' parameter.");
    }
});

app.Run();
