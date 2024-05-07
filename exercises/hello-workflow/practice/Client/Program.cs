// This file is designated to run the Workflow
using MyNamespace;
using Temporalio.Client;

// Create a client to localhost on "default" namespace
var client = await TemporalClient.ConnectAsync(new("localhost:7233"));

// Run workflow
var result = await client.ExecuteWorkflowAsync(
    (SayHelloWorkflow wf) => wf.RunAsync("World"),
    new(id: "my-workflow-id", taskQueue: "my-task-queue")); 

Console.WriteLine("Workflow result: {0}", result);

// TODO: modify the statement above to specify the task queue name (i.e - change the task queue to greeting-tasks)