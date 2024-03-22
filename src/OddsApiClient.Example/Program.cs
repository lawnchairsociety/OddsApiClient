using System.Text.Json;
using OddsApiClient.Requests;

namespace OddsApiClient.Example;

public class Program
{
    static async Task Main(string[] args)
    {
        var baseUrl = "https://api.the-odds-api.com";
        var apiKey = "6a5611df940c1d289ef3936433e04e6a"; // Add your free API Key here
        var clientOptions = new OddsApiClientOptions
        {
            BaseUrl = baseUrl,
            ApiKey = apiKey
        };
        var client = new OddsApiClient(clientOptions);

        // Retrieve Sports
        var request = new RetrieveSportsRequest
        {
            All = true
        };

        var response = await client.Sports.RetrieveSportsAsync(request);

        Console.WriteLine(JsonSerializer.Serialize(response));
    }
}
