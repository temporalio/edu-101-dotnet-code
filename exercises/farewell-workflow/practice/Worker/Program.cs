// This file is designated to run the Worker
using Temporalio.Client;
using Temporalio.Worker;
using TemporalioFarewell.Workflow;

// Create a client to localhost on "default" namespace
var client = await TemporalClient.ConnectAsync(new("localhost:7233"));

// Cancellation token to shutdown worker on ctrl+c
using var tokenSource = new CancellationTokenSource();
Console.CancelKeyPress += (_, eventArgs) =>
{
    tokenSource.Cancel();
    eventArgs.Cancel = true;
};

var activities = new TranslateActivities();

// Create worker
using var worker = new TemporalWorker(
    client,
    new TemporalWorkerOptions("farewell-workflow").
        AddAllActivities(activities).
        AddWorkflow<GreetingWorkflow>());

// Run worker until cancelled
Console.WriteLine("Running worker");
try
{
    await worker.ExecuteAsync(tokenSource.Token);
}
catch (OperationCanceledException)
{
    Console.WriteLine("Worker cancelled");
}
