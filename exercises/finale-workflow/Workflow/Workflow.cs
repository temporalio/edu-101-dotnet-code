using Temporalio.Workflows;

[Workflow]
public interface ICertificateGeneratorWorkflow
{
    [WorkflowRun]
    Task<string> RunAsync(string name);
}