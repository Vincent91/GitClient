using System.Net.Http.Headers;

namespace ApexServer;

public class GitClient
{
    private const string Url = "https://api.github.com/orgs/dotnet/repos";

    private readonly HttpClientHandler _handler;
    private readonly HttpClient _client;
    
    public GitClient()
    {
        _handler = new HttpClientHandler();
        _handler.UseDefaultCredentials = true;

        _client = new HttpClient(_handler);
        _client.DefaultRequestHeaders.Accept.Clear();
        _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
        _client.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");
    }

    public Task<string> RequestData(string data)
    {
        Console.WriteLine($"Requested data [${data}]");
        return _client.GetStringAsync(Url);
    }
    
}