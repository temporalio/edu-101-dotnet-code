using RetryPolicySample;
using Temporalio.Client;

// Create a client to localhost on "default" namespace
var client = await TemporalClient.ConnectAsync(new("localhost:7233"));

var result = await client.ExecuteWorkflowAsync(
    (RetryPolicySampleWorkflow wf) => wf.RunAsync("World"),
    new(id: $"retry-policy-sample-workflow-{Guid.NewGuid()}", taskQueue: "retry-policy-sample-tasks"));

Console.WriteLine($"retry-policy-sample-workflow-${Guid.NewGuid()}");