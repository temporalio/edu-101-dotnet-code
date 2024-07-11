using Temporalio.Client;
using Temporalio.Finale.Workflow;

// Create a client to localhost on "default" namespace
var client = await TemporalClient.ConnectAsync(new("localhost:7233"));

// TODO: Change 'Maxim Fateev' to your name
var result = await client.ExecuteWorkflowAsync(
    (CertificateGeneratorWorkflow wf) => wf.RunAsync("Maxim Fateev"),
    new(id: $"cert-generator-workflow-{Guid.NewGuid()}", taskQueue: "generate-certificate-taskqueue"));

Console.WriteLine($"Started workflow: cert-generator-workflow-${Guid.NewGuid()}");
Console.WriteLine($"You can find your certificate of completion here + ${result}");