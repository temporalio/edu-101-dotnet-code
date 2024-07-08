namespace RetryPolicySample;

using Temporalio.Workflows;

[Workflow]
public class RetryPolicySampleWorkflow
{
    [WorkflowRun]
    public async Task<string> RunAsync(string name)
    {
        var options = new ActivityOptions
        {
            StartToCloseTimeout = TimeSpan.FromSeconds(90), // Schedule a retry if the Activity function doesn't return within 90 seconds
            RetryPolicy = new()
            {
                BackoffCoefficient = 2, // double the delay after each retry
                InitialInterval = TimeSpan.FromSeconds(15), // first retry will occur after 15 seconds
                MaximumInterval = TimeSpan.FromMinutes(1), // up to a maximum delay of 1 minute
                MaximumAttempts = 100, // fail the Activity after 100 attempts
            },
        };

        return await Workflow.ExecuteActivityAsync(
            (MyActivities act) => act.SayHello(name),
            options);
    }
}
