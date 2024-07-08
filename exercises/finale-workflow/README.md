# Exercise 4: Finale Workflow

One of the benefits of Temporal is that it provides SDKs for several
languages and you can use multiple languages in the context of a single
Workflow. For example, you might write your Workflow in C# but use
Java or Go for an Activity in that Workflow.

The last exercise in this workshop does exactly that. The Workflow
itself is written in C#, but the Activity that is executed as part
of this Workflow is written in Java, as is the Worker that runs it. Since the Activity is
written in Java, it's able to use a Java graphics library that would otherwise be would be
incompatible with a typical C# program.

The bonus part of this exercise is that you get a certificate for completing this course.
In order to receive this certificate, you must change the default name in the Workflow
and follow the following steps below.

# Start the Worker (Java)

1. Change into the `finale-workflow` directory.
2. In one terminal, run the following command:

```sh
java -classpath java-activity-and-worker.jar io.temporal.training.PdfCertWorker
```

# Start the Worker (.NET)

In a new terminal, run the following command to run the C# Worker:

```sh
dotnet run --project Worker
```

# Edit the Workflow (.NET)

Open the [Program.cs](./Client/Program.cs) file, and change the argument passed to the Workflow from 'Maxim Fateev' to your name.

# Start the Workflow

Run the command below in another terminal to start the C# Workflow:

```sh
dotnet run --project Client
```

- Once the Workflow is complete, use the explorer view to locate the file created by this Workflow. It will have a name similar to `101_certificate_maxim_fateev.pdf`, only with your name in place of `maxim_fateev`.
- Right-click its icon and choose **Download...**.
- If you're running this on your local machine, look for the `101_certificate_{with_your_name}.pdf` in your `finale-workflow` folder where it can be downloaded. After you've downloaded it to your computer, feel free to open it with your preferred PDF viewer.

Thank you for participating in Temporal 101!

### This is the end of the exercise.
