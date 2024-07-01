namespace TemporalioHelloWorld.Workflow;

using Temporalio.Workflows;

[Workflow]
public class SayHelloWorkflow
{
    [WorkflowRun]
    public async Task<string> RunAsync(string name)
    {
        return await Workflow.ExecuteActivityAsync(
            (MyActivities act) => act.SayHello(name),
            new() { ScheduleToCloseTimeout = TimeSpan.FromMinutes(5) });
    }
}