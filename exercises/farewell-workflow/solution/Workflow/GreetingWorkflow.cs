using Temporalio.Workflows;
namespace Temporalio.Farewell.Workflow;

[Workflow]
public class GreetingWorkflow
{

    [WorkflowRun]
    public async Task<string> RunAsync(string name)
    {
        // Spanish greeting
        var greeting = await Workflow.ExecuteActivityAsync(
            () => TranslateActivities.GetSpanishGreeting(name),
            new() { ScheduleToCloseTimeout = TimeSpan.FromMinutes(3) });

        // Spanish farewell
        var farewell = await Workflow.ExecuteActivityAsync(
            () => TranslateActivities.GetSpanishFarewell(name),
            new() { ScheduleToCloseTimeout = TimeSpan.FromMinutes(3) });

        // Combine greeting and farewell into a single result
        return $"{greeting}\n{farewell}";
    }

}