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
            (TranslateActivities act) => act.GetSpanishGreetingAsync(name),
            new() { ScheduleToCloseTimeout = TimeSpan.FromMinutes(3) });

        // TODO: Change the line below to execute the Activity function you created
        var farewell = await Workflow.ExecuteActivityAsync(
            (TranslateActivities act) => act.GetSpanishGreetingAsync(name),
            new() { ScheduleToCloseTimeout = TimeSpan.FromMinutes(3) });

        // Greeting and farewell
        return $"{greeting}\n{farewell}";
    }
}