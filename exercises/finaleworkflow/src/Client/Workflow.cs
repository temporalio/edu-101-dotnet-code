using Temporalio.Workflows;

namespace Client;

[Workflow]
public interface ICertificateGeneratorWorkflow
{
    [WorkflowRun]
    Task<string> RunAsync(string name);
}