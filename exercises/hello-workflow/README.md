# Exercise 1: Hello Workflow

During this exercise, you will

- Review the business logic of the provided Workflow Definition to understand its behavior.
- Modify the Worker initialization code to specify a Task Queue name.
- Run the Worker initialization code to start the Worker process.
- Execute the Workflow from the command line, specifying your name as input.

Make your changes to the code in the `practice` subdirectory (look for TODO
comments that will guide you to where you should make changes to the code).
If you need a hint or want to verify your changes, look at the complete version
in the `solution` subdirectory.

## Part A: Review the Workflow Business Logic

1. Change into the practice subdirectory using the following command:

```bash
cd edu-101-dotnet-code/exercises/hello-workflow/practice/
```

2. Open the `SayHelloWorkflow.workflow.cs` file (located in the `Workflow` folder)
   in the editor.
3. Review the input parameters, business logic, and return value.

## Part B: Specify a Task Queue Name for the Worker

1. Open the `Program.cs` file (located in the `Client` folder) in the editor.
2. Write `greeting-tasks` as the name of the Task Queue.
3. Save your changes.
4. Repeat and open the `Program.cs` file in the `Worker` folder.
5. Write `greeting-tasks` as the name of the Task Queue and save.

## Part C: Start the Worker

1. Make sure you're in the practice subdirectory. You can do this by
   running `cd edu-101-dotnet-code/exercises/hello-workflow/practice/`.

2. Run the following command in the terminal window to start the Worker.

```
dotnet run --project Worker
```

You should see "Running worker" after running the command.

## Part D: Start the Workflow from the Command Line

1. Open another terminal window in the environment and change to the
   `Client` folder under `practice` for this exercise. You can do this by
   running `cd edu-101-dotnet-code/exercises/hello-workflow/practice/Client`.
2. Run the following command, replacing `Donna` with your own name.
   Be sure to retain the same quoting shown here when you run the command:

```
temporal workflow start \
    --type SayHelloWorkflow \
    --task-queue greeting-tasks \
    --workflow-id my-first-workflow \
    --input '"Donna"'
```

Notice the quoting for the input value, which has double quotes inside of single quotes. The input passed to the `temporal` command must be provided in JSON format and the quoting used here is necessary to pass the value through the shell and into the Workflow in the correct format.

Note that this command starts the Workflow, but it does not wait for
it to complete or show the result.

If you have time, continue with the optional part of the exercise
below to see how to use the `temporal` command to display the result.

### Using the CLI to Start a Workflow with Windows

The mix of single and double quotes we currently have pertains to UNIX-style shells. However, If you are running the Temporal CLI in Windows (such as Powershell), you will need to use Windows-style quote escaping like this:

```
temporal workflow start --type SayHelloWorkflow --task-queue greeting-tasks --workflow-id my-first-workflow --input '\"Donna\"'
```

This is a general Windows approach for handling quotes in parameters, not something specific to Temporal.

## Part E (Optional): Display the Result

You can run the following command to display the result of a Workflow Execution:

```bash
temporal workflow show --workflow-id my-first-workflow
```

It is also possible, and often more convenient, to view this information using
the Web UI. You will have a chance to do this in the next exercise.

### This is the end of the exercise.
