namespace TemporalioFarewell.Workflow;

using Temporalio.Workflows;

[Workflow]
public class GreetingWorkflow
{
    [WorkflowRun]
    public async Task<string> RunAsync(string name)
    {
        // Spanish greeting
        var greeting = await Workflow.ExecuteActivityAsync(
            () => TranslateActivities.GetSpanishGreetingAsync(name),
            new() { ScheduleToCloseTimeout = TimeSpan.FromMinutes(3) });

        // Spanish farewell
        var farewell = await Workflow.ExecuteActivityAsync(
            () => TranslateActivities.GetSpanishFarewellAsync(name),
            new() { ScheduleToCloseTimeout = TimeSpan.FromMinutes(3) });

        // Greeting and farewell
        return $"{greeting}\n{farewell}";
    }
}