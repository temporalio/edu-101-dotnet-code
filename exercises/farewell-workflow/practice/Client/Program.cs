// Run the Workflow file
using Temporalio.Client;
using Temporalio.Farewell.Workflow;

// Connect to the Temporal Service
var client = await TemporalClient.ConnectAsync(new("localhost:7233"));

// Generate a unique Workflow ID
var workflowId = $"greeting-{Guid.NewGuid()}";

// Prompt the user to enter their name and default to Temporal
Console.WriteLine("Please enter your name:");
var name = Console.ReadLine();
if (string.IsNullOrEmpty(name))
{
    name = args.FirstOrDefault() ?? "Temporal";
}

// Start the Workflow
var result = await client.ExecuteWorkflowAsync(
    (GreetingWorkflow wf) => wf.RunAsync(name),
    new(id: workflowId, taskQueue: "farewell-workflow"));

Console.WriteLine($"Workflow result: {result}");  // Output Workflow result
