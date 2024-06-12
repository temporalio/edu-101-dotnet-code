// Run Workflow file
using Temporalio.Client;
using Temporalio.Farewell.Workflow;

// Connect to the Temporal server
var client = await TemporalClient.ConnectAsync(new("localhost:7233") { Namespace = "default" });

var workflowId = $"greeting-{Guid.NewGuid()}";

// Default to "Temporal" and overriding if a valid argument is provided
var name = args.FirstOrDefault() ?? "Temporal";  // Default name

// If 'name' is "Temporal", prompt for user-input name
if (name == "Temporal") {
    Console.WriteLine("Please enter your name:");
    var userInput = Console.ReadLine();

    // Override 'name' if user input is not empty
    name = !string.IsNullOrEmpty(userInput) ? userInput : name;  // Keep default if input is empty
}

try
{
    // Start the workflow
    var handle = await client.StartWorkflowAsync(
        (GreetingWorkflow wf) => wf.RunAsync(name),
        new(id: workflowId, taskQueue: "farewell-workflow"));

    Console.WriteLine($"Started Workflow {workflowId}");

    // Await the result of the workflow
    var result = await handle.GetResultAsync();
    Console.WriteLine($"Workflow result: {result}");  // Output workflow result
}
catch (Exception ex)
{
    Console.Error.WriteLine($"Workflow execution failed: {ex.Message}");
}

