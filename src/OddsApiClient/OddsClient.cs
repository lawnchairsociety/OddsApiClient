using OddsApiClient.Requests;
using OddsApiClient.Mappers;
using RestSharp;
using RestSharp.Serializers.Json;
using OddsApiClient.Models;

namespace OddsApiClient;

public class OddsClient
  : IOddsClient
{
  public const string HistoricalSportEventOddsEndpoint = "/v4/historical/sports/{sport}/events/{eventId}/odds";
  public const string HistoricalSportEventsEndpoint = "/v4/historical/sports/{sport}/events";
  public const string HistoricalSportOddsEndpoint = "/v4/historical/sports/{sport}/odds";
  public const string SportEventOddsEndpoint = "/v4/sports/{sport}/events/{eventId}/odds";
  public const string SportEventsEndpoint = "/v4/sports/{sport}/events";
  public const string SportOddsEndpoint = "/v4/sports/{sport}/odds";
  public const string SportsEndpoint = "/v4/sports";
  public const string SportScoresEndpoint = "/v4/sports/{sport}/scores";

  private readonly RestClient _client;

  public OddsClient(string baseUrl, string apiKey)
  {
    this._client = new RestClient(new RestClientOptions(baseUrl),
      useClientFactory: true,
      configureSerialization: s=> s.UseSystemTextJson(new(System.Text.Json.JsonSerializerDefaults.Web)));
    
    this._client.AddDefaultParameter("apiKey", apiKey);
  }


  /// <inheritdoc/>
  public async Task<List<Sport>> RetrieveSportsAsync(RetrieveSportsRequest request, CancellationToken cancellation = default)
  {
      cancellation.ThrowIfCancellationRequested();
      var restRequest = request.ToRestRequest();
      var response = await this._client.ExecuteAsync<List<Sport>>(restRequest, cancellation);

      if (response.IsSuccessful)
        return response.Data!;
      
      throw this._client.BuildExceptionFromResponse(response);
  }

  /// <inheritdoc/>
  public async Task<List<SportScores>> RetrieveSportScoresAsync(RetrieveSportScoresRequest request, CancellationToken cancellation = default)
  {
      cancellation.ThrowIfCancellationRequested();
      var restRequest = request.ToRestRequest();
      var response = await this._client.ExecuteAsync<List<SportScores>>(restRequest, cancellation);

      if (response.IsSuccessful)
        return response.Data!;
      
      throw this._client.BuildExceptionFromResponse(response);
  }

  /// <inheritdoc/>
  public async Task<List<Event>> RetrieveSportEventsAsync(RetrieveSportEventsRequest request, CancellationToken cancellation = default)
  {
      cancellation.ThrowIfCancellationRequested();
      var restRequest = request.ToRestRequest();
      var response = await this._client.ExecuteAsync<List<Event>>(restRequest, cancellation);

      if (response.IsSuccessful)
        return response.Data!;
      
      throw this._client.BuildExceptionFromResponse(response);
  }

  /// <inheritdoc/>
  public async Task<List<Odds>> RetrieveSportOddsAsync(RetrieveSportOddsRequest request, CancellationToken cancellation = default)
  {
      cancellation.ThrowIfCancellationRequested();
      var restRequest = request.ToRestRequest();
      var response = await this._client.ExecuteAsync<List<Odds>>(restRequest, cancellation);

      if (response.IsSuccessful)
        return response.Data!;
      
      throw this._client.BuildExceptionFromResponse(response);
  }

  /// <inheritdoc/>
  public async Task<List<Odds>> RetrieveSportEventOddsAsync(RetrieveSportEventOddsRequest request, CancellationToken cancellation = default)
  {
      cancellation.ThrowIfCancellationRequested();
      var restRequest = request.ToRestRequest();
      var response = await this._client.ExecuteAsync<List<Odds>>(restRequest, cancellation);

      if (response.IsSuccessful)
        return response.Data!;
      
      throw this._client.BuildExceptionFromResponse(response);
  }

  /// <inheritdoc/>
  public async Task<List<HistoricalEvents>> RetrieveHistoricalSportEventsAsync(RetrieveHistoricalSportEventsRequest request, CancellationToken cancellation = default)
  {
      cancellation.ThrowIfCancellationRequested();
      var restRequest = request.ToRestRequest();
      var response = await this._client.ExecuteAsync<List<HistoricalEvents>>(restRequest, cancellation);
  
      if (response.IsSuccessful)
        return response.Data!;

        Console.WriteLine(this._client.BuildUri(restRequest).ToString());
      
      throw this._client.BuildExceptionFromResponse(response);
  }

  /// <inheritdoc/>
  public async Task<List<HistoricalSportOdds>> RetrieveHistoricalSportOddsAsync(RetrieveHistoricalSportOddsRequest request, CancellationToken cancellation = default)
  {
      cancellation.ThrowIfCancellationRequested();
      var restRequest = request.ToRestRequest();
      var response = await this._client.ExecuteAsync<List<HistoricalSportOdds>>(restRequest, cancellation);

      if (response.IsSuccessful)
        return response.Data!;
      
      throw this._client.BuildExceptionFromResponse(response);
  }

  /// <inheritdoc/>
  public async Task<HistoricalEventOdds> RetrieveHistoricalSportEventOddsAsync(RetrieveHistoricalSportEventOddsRequest request, CancellationToken cancellation = default)
  {
      cancellation.ThrowIfCancellationRequested();
      var restRequest = request.ToRestRequest();
      var response = await this._client.ExecuteAsync<HistoricalEventOdds>(restRequest, cancellation);

      if (response.IsSuccessful)
        return response.Data!;
      
      throw this._client.BuildExceptionFromResponse(response);
  }
}
