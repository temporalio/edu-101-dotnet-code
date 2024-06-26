namespace Temporalio.Finale.Workflow;
using Temporalio.Activities;
public interface IJavaActivities
{
    [Activity]

    // CreatePdf is the Activity Type defined in the implementation of the Java Activity code.
    public string CreatePdf(string name);
}
