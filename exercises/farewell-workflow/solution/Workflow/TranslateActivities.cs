namespace TemporalioFarewell.Workflow;

using Temporalio.Activities;

public class TranslateActivities
{
    private static readonly HttpClient client = new();

    [Activity]
    public static async Task<string> GetSpanishGreeting(string name)
    {
        var encodedName = Uri.EscapeDataString(name);
        var response = await client.GetAsync($"http://localhost:5125/get-spanish-greeting?name={encodedName}");
        return await response.Content.ReadAsStringAsync();
    }

     [Activity]
    public static async Task<string> GetSpanishFarewell(string name)
    {
        var encodedName = Uri.EscapeDataString(name);
        var response = await client.GetAsync($"http://localhost:5125/get-spanish-farewell?name={encodedName}");
        return await response.Content.ReadAsStringAsync();
    }
}
