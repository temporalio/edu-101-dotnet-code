namespace TemporalioFarewell.Workflow;

using Temporalio.Activities;

public static class TranslateActivities
{
    private static readonly HttpClient Client = new();

    [Activity]
    public static async Task<string> GetSpanishGreetingAsync(string name)
    {
        var encodedName = Uri.EscapeDataString(name);
        var response = await Client.GetAsync($"http://localhost:5125/get-spanish-greeting?name={encodedName}");
        return await response.Content.ReadAsStringAsync();
    }

    // TODO Part A: Copy the GetSpanishGreeting method to create a new Activity
    // Rename the new Activity GetSpanishFarewell.
}
