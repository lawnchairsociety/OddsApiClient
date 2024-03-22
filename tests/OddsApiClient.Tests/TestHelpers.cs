using RestSharp;
using RestSharp.Serializers.Json;

namespace OddsApiClient.Tests;

public static class TestHelpers
{
    public static RestClient GetRestClient(HttpMessageHandler handler)
    {
        var options = new RestClientOptions("https://localhost")
        {
            ConfigureMessageHandler = _ => handler
        };

        var restClient = new RestClient(
          options: options,
          useClientFactory: false,
          configureSerialization: s => s.UseSystemTextJson(new(System.Text.Json.JsonSerializerDefaults.Web))
        );

        return restClient;
    }
}
