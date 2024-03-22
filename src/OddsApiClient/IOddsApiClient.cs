using RestSharp;
using RestSharp.Serializers.Json;

namespace OddsApiClient;

/// <summary>
/// Defines a client that interfaces with the Odds API platform
/// </summary>
public interface IOddsApiClient
{
  /// <summary>
  /// A client for interfacing with the 'Sports' endpoint
  /// </summary>
  ISportsClient Sports { get; }

  /// <summary>
  /// A client for interfacing with the 'Events' endpoint
  /// </summary>
  IEventsClient Events { get; }

  /// <summary>
  /// A client for interfacing with the 'Historical' endpoint
  /// </summary>
  IHistoricalClient Historical { get; }
}

public class OddsApiClient
  : IOddsApiClient
{
  public OddsApiClient(OddsApiClientOptions options)
  {
    options.Validate();

    var clientOptions = new RestClientOptions(options.BaseUrl);
    var client = new RestClient(
      options: clientOptions,
      useClientFactory: true,
      configureSerialization: s => s.UseSystemTextJson(new(System.Text.Json.JsonSerializerDefaults.Web))
    );
    
    client.AddDefaultParameter("apiKey", options.ApiKey);

    this.Sports = new SportsClient(client);
    this.Events = new EventsClient(client);
    this.Historical = new HistoricalClient(client);
  }

    public ISportsClient Sports { get; }

    public IEventsClient Events { get; }

    public IHistoricalClient Historical { get; }
}