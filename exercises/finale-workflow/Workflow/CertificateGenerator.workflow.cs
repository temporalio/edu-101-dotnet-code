namespace Temporalio.Finale.Workflow;

using Temporalio.Workflows;

[Workflow]
public class CertificateGeneratorWorkflow
{
    [WorkflowRun]
    public async Task<string> RunAsync(string name)
    {
        // The CertificateGeneratorWorkflow Workflow calls the CreatePdf Activity.
        return await Workflow.ExecuteActivityAsync(
            (IJavaActivities act) => act.CreatePdf(name),
            new() { StartToCloseTimeout = TimeSpan.FromSeconds(5) });
    }
}
