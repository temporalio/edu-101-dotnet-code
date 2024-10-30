namespace TemporalioFarewell.Workflow;

using Temporalio.Activities;
public class TranslateActivities
{
    private static readonly HttpClient Client = new();

    [Activity]
    public async Task<string> GetSpanishGreetingAsync(string name)
    {
        var encodedName = Uri.EscapeDataString(name);
        var response = await Client.GetAsync($"http://localhost:5125/get-spanish-greeting?name={encodedName}");
        return await response.Content.ReadAsStringAsync();
    }

    [Activity]
    public async Task<string> GetSpanishFarewellAsync(string name)
    {
        var encodedName = Uri.EscapeDataString(name);
        var response = await Client.GetAsync($"http://localhost:5125/get-spanish-farewell?name={encodedName}");
        return await response.Content.ReadAsStringAsync();
    }
}