namespace TemporalioHelloWorld.Workflow;

using Temporalio.Activities;

public class MyActivities
{
    [Activity]
    public string SayHello(string name) => $"Hello, {name}!";
}