// Translate Activities
namespace Temporalio.Farewell.Workflow;
using Temporalio.Activities;

public class TranslateActivities
{
    public static HttpClient client = new HttpClient();

    [Activity]
    public static async Task<string> GetSpanishGreeting(string name)
    {
        var response = await client.GetAsync($"http://localhost:5125/get-spanish-greeting?name={name}");
        return await response.Content.ReadAsStringAsync();
    }

    // TODO Part A: Copy the GetSpanishGreeting method to create a new Activity
    // Rename the new Activity GetSpanishFarewell.
}
