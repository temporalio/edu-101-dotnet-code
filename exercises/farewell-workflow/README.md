# Exercise 3: Farewell Workflow

During this exercise, you will create an Activity function,
register it with the Worker, and modify a Workflow to execute it.

Before continuing, press Ctrl-C to stop any Worker instances still running from any
previous exercises.

As with other exercises, you should make your changes in the `practice`
directory. Look for "TODO" comments, which will provide hints about what
you'll need to change. If you get stuck and need additional hints, or
if you want to check your work, look at the completed example in the
`solution` directory.

## Part A: Write an Activity Function

The `TranslateActivities.cs` file contains a method(`GetSpanishGreeting`) that uses a
microservice to get a customized greeting in Spanish. Follow these steps to create
a new Activity that gets a custom farewell message from the microservice:

1. Open the `TranslateActivities.cs` file. This is located in the
   `exercises/farewell-workflow/practice/Workflow` subdirectory.
2. Create a new Activity that will get a custom farewell message. 
3. Copy the `GetSpanishGreeting` method to create a new Activity. 
4. Modify the Activity to call `GetSpanishFarewell` 
5. Rename the new `GetSpanishGreeting` function to `GetSpanishFarewell`. 
6. Save your changes to this file.

## Part B: Modify the Workflow to Execute Your New Activity

1. Open the `GreetingWorkflow.workflow.cs` file (located in the `practice/Workflow` subdirectory) in the editor.
2. Add your new Activity to the list of Activities that will use the Activity options below (hint: you'll use the name you used for the new function in the first step).
3. Look for the TODO message, uncomment the line below it, and then change that line to execute the Activity function you created.
4. Save your changes to this file.

## Part C: Start the Microservice and Run the Workflow

If you're using the Gitpod environment to run this exercise, you don't
need to run the Temporal Service on your local environment.

If you are on your local environment, make sure the Temporal Service is
running in the background. This is done by opening a new terminal window
and running the following command:
`temporal server start-dev --ui-port 8080 --db-filename clusterdata.db`.
For more details on this command, please refer to the
`Setting up a Local Development Environment` chapter in the course.

### Run the Microservice

1. Open a terminal and navigate to the `practice` subdirectory
   (`cd exercises/farewell-workflow/practice`) through the terminal.
2. Run the following command in a new terminal to start the microservice:
   `dotnet run --project Web`.

### Start the Worker

1. In another terminal, navigate to the `practice` subdirectory
   (`cd exercises/farewell-workflow/practice`), start your Worker by
   running: `dotnet run --project Worker`.

### Execute the Workflow:

1. Open a third terminal in the `practice` subdirectory
   (`cd exercises/farewell-workflow/practice`).
2. Run your workflow by the following command:
   `dotnet run --project Client -- "Donna"` (replacing `Donna`
   with your own name or run `dotnet run --project Client` and
   enter your name in the terminal).

If there is time remaining, experiment with Activity failures and retries
by stopping the microservice (press Ctrl-C in its terminal) and re-running
the Workflow. Look at the Web UI to see the status of the Workflow and its
Activities. After a few seconds, restart the microservice by running the
same command used to start it earlier. You should find that the Workflow
will now complete successfully following the next Activity retry.
