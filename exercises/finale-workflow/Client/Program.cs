using Temporalio.Client;
using Temporalio.Finale.Workflow;

// Create a client to localhost on "default" namespace
var client = await TemporalClient.ConnectAsync(new("localhost:7233"));

// TODO: Change 'Maxim Fateev' to your name
<<<<<<< HEAD
var handle = await client.StartWorkflowAsync((CertificateGeneratorWorkflow wf) => wf.RunAsync("Maxim Fateev"),
    new WorkflowOptions
    {
        TaskQueue = "generate-certificate-taskqueue", 
        Id = "cert-generator-workflow-" + Guid.NewGuid()
    });
=======
var result = await client.ExecuteWorkflowAsync(
    (CertificateGeneratorWorkflow wf) => wf.RunAsync("Maxim Fateev"),
    new(id: $"cert-generator-workflow-{Guid.NewGuid()}", taskQueue: "generate-certificate-taskqueue"));
>>>>>>> 0d412f5bb8f01057e0a67461d7046511eee05ed3

Console.WriteLine($"Started workflow: cert-generator-workflow-${Guid.NewGuid()}");
Console.WriteLine($"You can find your certificate of completion here + ${result}");