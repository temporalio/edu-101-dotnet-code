namespace TemporalioFarewell.Workflow;

using Temporalio.Activities;
public sealed class TranslateActivities : IDisposable
{
    private readonly HttpClient client;
    private bool disposed;

    public TranslateActivities(HttpClient client)
    {
        this.client = client ?? throw new ArgumentNullException(nameof(client));
    }

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

    public void Dispose()
    {
        if (!disposed)
        {
            client?.Dispose();
            disposed = true;
        }
    }
}