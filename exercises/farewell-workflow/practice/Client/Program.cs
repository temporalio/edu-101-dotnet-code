// Run the Workflow file
using Temporalio.Client;
using TemporalioFarewell.Workflow;

// Connect to the Temporal Service
var client = await TemporalClient.ConnectAsync(new("localhost:7233"));

// Generate a unique Workflow ID
var workflowId = $"greeting-{Guid.NewGuid()}";

var name = args.FirstOrDefault();

if (string.IsNullOrEmpty(name))
{
    Console.WriteLine("Please enter your name:");
    name = Console.ReadLine();
}

name = string.IsNullOrEmpty(name) ? "Temporal" : name;

// Start the Workflow
var result = await client.ExecuteWorkflowAsync(
    (GreetingWorkflow wf) => wf.RunAsync(name),
    new(id: workflowId, taskQueue: "farewell-workflow"));

Console.WriteLine($"Workflow result: {result}");  // Output Workflow result
