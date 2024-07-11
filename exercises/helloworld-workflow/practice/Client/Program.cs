// This file is designated to run the Workflow
using TemporalioHelloWorld.Workflow;
using Temporalio.Client;

// Create a client to localhost on "default" namespace
var client = await TemporalClient.ConnectAsync(new("localhost:7233"));

// Run workflow
var result = await client.ExecuteWorkflowAsync(
    (SayHelloWorkflow wf) => wf.RunAsync("World"),
    new(id: "my-workflow-id", taskQueue: "my-task-queue")); 

Console.WriteLine($"Workflow result: {result}");

// TODO PART B: modify the statement above to specify the Task Queue name (i.e - change the Task Queue to greeting-tasks)