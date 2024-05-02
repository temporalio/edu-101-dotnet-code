using Temporalio.Client;
using MyNamespace;

var client = await TemporalClient.ConnectAsync(new ()
{
    TargetHost = "localhost:7233",
});

// TODO: Change 'Maxim Fateev' to your name
var handle = await client.StartWorkflowAsync((CertificateGeneratorWorkflow wf) => wf.RunAsync("Maxim Fateev"),
    new WorkflowOptions
    {
        TaskQueue = "generate-certificate-taskqueue",
        Id = "cert-generator-workflow-" + Guid.NewGuid()
    });

Console.WriteLine("Started workflow {0}", handle.Id);
Console.WriteLine("You can find your certificate of completion here: " + await handle.GetResultAsync());
