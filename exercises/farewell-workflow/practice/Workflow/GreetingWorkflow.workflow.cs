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

        // TODO: uncomment the line below and change it to execute the Activity function you created
        // var farewell = await Workflow.ExecuteActivityAsync(
        //     () => TranslateActivities.GetSpanishFarewellAsync(name),
            new() { ScheduleToCloseTimeout = TimeSpan.FromMinutes(3) });

        // Greeting and farewell
        return $"{greeting}\n{farewell}";
    }
}