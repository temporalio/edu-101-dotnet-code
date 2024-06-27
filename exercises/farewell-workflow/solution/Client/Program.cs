// Run the Workflow file
using Temporalio.Client;
using TemporalioFarewell.Workflow;

// Connect to the Temporal Service
var client = await TemporalClient.ConnectAsync(new("localhost:7233"));

// Generate a unique Workflow ID
var workflowId = $"greeting-{Guid.NewGuid()}";

// Prompt the user to enter their name and default to Temporal
// Check if the name is provided as a command-line argument
var name = args.FirstOrDefault();

if (string.IsNullOrEmpty(name))
{
    // Prompt the user to enter their name if not provided in args
    Console.WriteLine("Please enter your name:");
    name = Console.ReadLine();
    if (string.IsNullOrEmpty(name))
    {
        name = "Temporal"; // Default to "Temporal" if the input is still empty
    }
}

// Start the Workflow
var result = await client.ExecuteWorkflowAsync(
    (GreetingWorkflow wf) => wf.RunAsync(name),
    new(id: workflowId, taskQueue: "farewell-workflow"));

Console.WriteLine($"Workflow result: {result}");  // Output Workflow result
