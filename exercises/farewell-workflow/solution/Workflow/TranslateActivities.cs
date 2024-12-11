namespace TemporalioFarewell.Solution.Workflow;

using Temporalio.Activities;

public class TranslateActivities
{
    private readonly HttpClient client;

    public TranslateActivities(HttpClient client) => this.client = client;

    [Activity]
    public async Task<string> GetSpanishGreetingAsync(string name)
    {
        var encodedName = Uri.EscapeDataString(name);
        var response = await client.GetAsync($"http://localhost:5125/get-spanish-greeting?name={encodedName}");
        return await response.Content.ReadAsStringAsync();
    }

    [Activity]
    public async Task<string> GetSpanishFarewellAsync(string name)
    {
        var encodedName = Uri.EscapeDataString(name);
        var response = await client.GetAsync($"http://localhost:5125/get-spanish-farewell?name={encodedName}");
        return await response.Content.ReadAsStringAsync();
    }
}