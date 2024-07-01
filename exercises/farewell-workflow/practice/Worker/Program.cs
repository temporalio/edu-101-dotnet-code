// Run Worker
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Temporalio.Extensions.Hosting;
using TemporalioFarewell.Workflow;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureLogging(ctx =>
        ctx.AddSimpleConsole().SetMinimumLevel(LogLevel.Information))
    .ConfigureServices(ctx =>
        ctx.AddHostedTemporalWorker(
            clientTargetHost: "localhost:7233",
            clientNamespace: "default",
            taskQueue: "farewell-workflow")
            .AddStaticActivities<TranslateActivities>() // Add Activities
            .AddWorkflow<GreetingWorkflow>()) // Add Workflow
    .Build();

await host.RunAsync();
