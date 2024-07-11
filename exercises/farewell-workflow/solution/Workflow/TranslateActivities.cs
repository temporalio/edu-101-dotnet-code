namespace TemporalioFarewell.Workflow;

using Temporalio.Activities;
using Temporalio.Client;

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

    [Activity]
    public static async Task<string> GetSpanishFarewellAsync(string name)
    {
        var encodedName = Uri.EscapeDataString(name);
        var response = await Client.GetAsync($"http://localhost:5125/get-spanish-farewell?name={encodedName}");
        return await response.Content.ReadAsStringAsync();
    }
}
