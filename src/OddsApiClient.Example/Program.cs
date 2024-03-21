using System.Text.Json;
using OddsApiClient.Requests;

namespace OddsApiClient.Example;

public class Program
{
  static async Task Main(string[] args)
  {
    var baseUrl = "https://api.the-odds-api.com";
    var apiKey = ""; // Add your free API Key here
    var client = new OddsClient(baseUrl, apiKey);
    
    // Retrieve Sports
    var request = new RetrieveSportsRequest
    {
      All = true
    };

    var response = await client.RetrieveSportsAsync(request);

    Console.WriteLine(JsonSerializer.Serialize(response));
  }
}