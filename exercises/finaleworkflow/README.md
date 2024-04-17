# Exercise 4: Finale Workflow

One of the benefits of Temporal is that it provides SDKs for several
languages and you can use multiple languages in the context of a single
Workflow. For example, you might write your Workflow in TypeScript but use
Java or Go for an Activity in that Workflow.

The last exercise in this workshop does exactly that. The Workflow
itself is written in c#, but the Activity that is executed as part
of this Workflow is written in Java, as is the Worker that runs it.
Since the Activity is written in Java, it's able to use a Java graphics
library that would otherwise be would be incompatible with a typical
c# program.

# Start the Worker (Java)

1. Change into the `finaleworkflow` directory.
2. In one terminal, run the following command:

```sh
java -classpath java-activity-and-worker.jar io.temporal.training.PdfCertWorker
```

# Edit the Workflow (dotnet)

Open the [Program.cs](./src/Client/Program.cs) file, and change the argument passed to the Workflow from 'Maxim Fateev' to your name.

# Start the Workflow (dotnet)

1. Change into the `src` directory.
2. Run the command below in another terminal to start the Workflow:

```sh
dotnet run --project Client/Client.csproj
```

- Once the Workflow is complete, use the explorer
  view to locate the file created by this Workflow. It
  will have a name similar to `101_certificate_maxim_fateev.pdf`,
  only with your name in place of `maxim_fateev`.
- Right-click its icon and choose **Download...**.
- After you've downloaded it to your
  computer, open it with your preferred PDF viewer.

Thank you for participating in Temporal 101!

### This is the end of the exercise.
