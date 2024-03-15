using OddsApiClient.Requests;
using OddsApiClient.Responses;
using OddsApiClient.Mappers;
using RestSharp;

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

  public OddsClient(RestClient client)
  {
    this._client = client;
  }

  /// <inheritdoc/>
  public async Task<RetrieveHistoricalSportEventOddsResponse> RetrieveHistoricalSportEventOddsAsync(RetrieveHistoricalSportEventOddsRequest request, CancellationToken cancellation = default)
  {
      cancellation.ThrowIfCancellationRequested();
      var restRequest = request.ToRestRequest();
      var response = await this._client.ExecuteAsync<RetrieveHistoricalSportEventOddsResponse>(restRequest, cancellation);

      if (response.IsSuccessful)
        return response.Data!;
      
      throw this._client.BuildExceptionFromResponse(response);
  }

  /// <inheritdoc/>
  public async Task<RetrieveHistoricalSportEventsResponse> RetrieveHistoricalSportEventsAsync(RetrieveHistoricalSportEventsRequest request, CancellationToken cancellation = default)
  {
      cancellation.ThrowIfCancellationRequested();
      var restRequest = request.ToRestRequest();
      var response = await this._client.ExecuteAsync<RetrieveHistoricalSportEventsResponse>(restRequest, cancellation);

      if (response.IsSuccessful)
        return response.Data!;
      
      throw this._client.BuildExceptionFromResponse(response);
  }

  /// <inheritdoc/>
  public async Task<RetrieveHistoricalSportOddsResponse> RetrieveHistoricalSportOddsAsync(RetrieveHistoricalSportOddsRequest request, CancellationToken cancellation = default)
  {
      cancellation.ThrowIfCancellationRequested();
      var restRequest = request.ToRestRequest();
      var response = await this._client.ExecuteAsync<RetrieveHistoricalSportOddsResponse>(restRequest, cancellation);

      if (response.IsSuccessful)
        return response.Data!;
      
      throw this._client.BuildExceptionFromResponse(response);
  }

  /// <inheritdoc/>
  public async Task<RetrieveSportEventOddsResponse> RetrieveSportEventOddsAsync(RetrieveSportEventOddsRequest request, CancellationToken cancellation = default)
  {
      cancellation.ThrowIfCancellationRequested();
      var restRequest = request.ToRestRequest();
      var response = await this._client.ExecuteAsync<RetrieveSportEventOddsResponse>(restRequest, cancellation);

      if (response.IsSuccessful)
        return response.Data!;
      
      throw this._client.BuildExceptionFromResponse(response);
  }

  /// <inheritdoc/>
  public async Task<RetrieveSportEventsResponse> RetrieveSportEventsAsync(RetrieveSportEventsRequest request, CancellationToken cancellation = default)
  {
      cancellation.ThrowIfCancellationRequested();
      var restRequest = request.ToRestRequest();
      var response = await this._client.ExecuteAsync<RetrieveSportEventsResponse>(restRequest, cancellation);

      if (response.IsSuccessful)
        return response.Data!;
      
      throw this._client.BuildExceptionFromResponse(response);
  }

  /// <inheritdoc/>
  public async Task<RetrieveSportOddsResponse> RetrieveSportOddsAsync(RetrieveSportOddsRequest request, CancellationToken cancellation = default)
  {
      cancellation.ThrowIfCancellationRequested();
      var restRequest = request.ToRestRequest();
      var response = await this._client.ExecuteAsync<RetrieveSportOddsResponse>(restRequest, cancellation);

      if (response.IsSuccessful)
        return response.Data!;
      
      throw this._client.BuildExceptionFromResponse(response);
  }

  /// <inheritdoc/>
  public async Task<RetrieveSportsResponse> RetrieveSportsAsync(RetrieveSportsRequest request, CancellationToken cancellation = default)
  {
      cancellation.ThrowIfCancellationRequested();
      var restRequest = request.ToRestRequest();
      var response = await this._client.ExecuteAsync<RetrieveSportsResponse>(restRequest, cancellation);

      if (response.IsSuccessful)
        return response.Data!;
      
      throw this._client.BuildExceptionFromResponse(response);
  }

  /// <inheritdoc/>
  public async Task<RetrieveSportScoresResponse> RetrieveSportScoresAsync(RetrieveSportScoresRequest request, CancellationToken cancellation = default)
  {
      cancellation.ThrowIfCancellationRequested();
      var restRequest = request.ToRestRequest();
      var response = await this._client.ExecuteAsync<RetrieveSportScoresResponse>(restRequest, cancellation);

      if (response.IsSuccessful)
        return response.Data!;
      
      throw this._client.BuildExceptionFromResponse(response);
  }
}
