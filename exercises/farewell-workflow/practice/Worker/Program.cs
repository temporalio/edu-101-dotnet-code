// run worker
using Temporalio.Extensions.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using Temporalio.Farewell.Workflow;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureLogging(ctx =>
        ctx.AddSimpleConsole().SetMinimumLevel(LogLevel.Information))
    .ConfigureServices(ctx =>
        ctx.AddHostedTemporalWorker(
            clientTargetHost: "localhost:7233",
            clientNamespace: "default",
            taskQueue: "farewell-workflow").
        AddStaticActivities(typeof(TranslateActivities)). // add activities
        AddWorkflow<GreetingWorkflow>()) // add workflow
    .Build();

await host.RunAsync();
