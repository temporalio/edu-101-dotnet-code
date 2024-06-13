// Translate Activities
namespace Temporalio.Farewell.Workflow;

using Temporalio.Activities;

public class TranslateActivities
{
    private static readonly HttpClient client = new();

    [Activity]
    public static async Task<string> GetSpanishGreeting(string name)
    {
        var response = await client.GetAsync($"http://localhost:5125/get-spanish-greeting?name={name}");
        return await response.Content.ReadAsStringAsync();
    }

     [Activity]
    public static async Task<string> GetSpanishFarewell(string name)
    {
        var response = await client.GetAsync($"http://localhost:5125/get-spanish-farewell?name={name}");
        return await response.Content.ReadAsStringAsync();
    }
}
