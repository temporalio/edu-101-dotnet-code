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

host.Run();

// Run worker until cancelled
 Console.WriteLine("Running worker");
 try
 {
     await worker.ExecuteAsync(tokenSource.Token);
 }
 catch (OperationCanceledException)
 {
     Console.WriteLine("Worker cancelled");