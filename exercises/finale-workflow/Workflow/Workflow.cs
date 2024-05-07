using Temporalio.Workflows;
namespace MyNamespace;

[Workflow]
public class CertificateGeneratorWorkflow
{
    [WorkflowRun]
    public async Task<string> RunAsync(string name)
    {
        // The CertificateGeneratorWorkflow Workflow calls the CreatePdf Activity. 
        // CreatePdf is the Activity Type defined in the implementation of the Java Activity code.
        return await Workflow.ExecuteActivityAsync<string>("CreatePdf", new object[] { name }, new()
        {
            StartToCloseTimeout = TimeSpan.FromSeconds(5)
        });
    }
}