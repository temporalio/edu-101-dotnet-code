using Temporalio.Workflows;
namespace MyNamespace;

[Workflow]
public class CertificateGeneratorWorkflow
{
    [WorkflowRun]
    public async Task<string> RunAsync(string name)
    {
        // Adjust the "CreatePdf" activity type and method call to reflect the actual implementation in Java.
        return await Workflow.ExecuteActivityAsync<string>("CreatePdf", new object[] { name }, new()
        {
            StartToCloseTimeout = TimeSpan.FromSeconds(5)
        });
    }
}