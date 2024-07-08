# Sample: Retry Policy

This samplele ilustrates how to use a retry policy in a Workflow. You can see the retry policy in `RetryPolicySample.workflow.cs`.

- Initial Interval: Amount of time that must elapse before the first retry occurs
- Backoff Coefficient: How much the retry interval increases (default is 2.0)
- Maximum Interval: The maximum interval between retries
- Maximum Attempts: The maximum number of execution attempts that can be made in the presence of failures
- Start-To-Close Timeout: The maximum time allowed for a single Activity Task Execution.
- Schedule-To-Close Timeout: The maximum amount of time allowed for the overall Activity Execution, from when the first Activity Task is scheduled to when the last Activity Task.