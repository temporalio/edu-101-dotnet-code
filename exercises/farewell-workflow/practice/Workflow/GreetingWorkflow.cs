namespace Temporalio.Farewell.Workflow;
using Temporalio.Workflows;

[Workflow]
public class GreetAndFarewell
{

    [WorkflowRun]
    public async Task<string> RunAsync(string name)
    {
        // Spanish greeting
        var greeting = await Workflow.ExecuteActivityAsync(
            () => TranslateActivities.GetSpanishGreeting(name),
            new() { ScheduleToCloseTimeout = TimeSpan.FromMinutes(3) });
        
        // TODO Part C: Uncomment the commented lines below
        // To execute the GetSpanishFarewell Activity
        // Spanish farewell
        // var farewell = await Workflow.ExecuteActivityAsync(
        //     () => TranslateActivities.GetSpanishFarewell(name),
        //     new() { ScheduleToCloseTimeout = TimeSpan.FromMinutes(3) });

        // Combine greeting and farewell into a single result
        return $"{greeting}\n{farewell}";
    }

}