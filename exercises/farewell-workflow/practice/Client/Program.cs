// Run the Workflow file
using Temporalio.Client;
using Temporalio.Farewell.Workflow;

// Connect to the Temporal Service
var client = await TemporalClient.ConnectAsync(new("localhost:7233"));

var workflowId = $"greeting-{Guid.NewGuid()}";

var name = args.FirstOrDefault();
if (string.IsNullOrEmpty(name)) {
    Console.WriteLine("Please enter your name:");
    name = Console.ReadLine();
    name = !string.IsNullOrEmpty(name) ? name : "Temporal";  // Keep default if input is empty
}

// Start the Workflow
var result = await client.ExecuteWorkflowAsync(
    (GreetingWorkflow wf) => wf.RunAsync(name),
    new(id: workflowId, taskQueue: "farewell-workflow"));

Console.WriteLine($"Workflow result: {result}");  // Output Workflow result
