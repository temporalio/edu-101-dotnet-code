using Temporalio.Workflows;
namespace Temporalio.FinaleWorkflow.CertificateGeneratorWorkflow;

[Workflow]
public interface ICertificateGeneratorWorkflow
{
    [WorkflowRun]
    Task<string> RunAsync(string name);
}