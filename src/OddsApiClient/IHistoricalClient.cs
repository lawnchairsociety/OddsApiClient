using OddsApiClient.Exceptions;
using OddsApiClient.Extensions;
using OddsApiClient.Requests;
using OddsApiClient.Models;
using OddsApiClient.Mappers;
using RestSharp;

namespace OddsApiClient;

public interface IHistoricalClient
{
  /// <summary>
  /// Retrieves events for the specified sport as they appeared at the specified timestamp (date parameter). Odds are not included in the response.
  /// </summary>
  /// <param name="request">The request.</param>
  /// <param name="cancellation">The token used to cancel the operation.</param>
  /// <returns>The response.</returns>
  /// <exception cref="OddsApiClientUnauthorizedException"></exception>
  /// <exception cref="OddsApiClientInvalidParameterException"></exception>
  /// <exception cref="OddsApiClientTooManyRequestsException"></exception>
  /// <exception cref="OddsApiClientInternalErrorException"></exception>
  Task<List<HistoricalEvents>> RetrieveHistoricalSportEventsAsync(RetrieveHistoricalSportEventsRequest request,CancellationToken cancellation = default);
}

public class HistoricalClient
  : IHistoricalClient
{
  internal const string HistoricalSportEventsEndpoint = "/v4/historical/sports/{sport}/events";
  internal const string HistoricalSportEventOddsEndpoint = "/v4/historical/sports/{sport}/events/{eventId}/odds";
  internal const string HistoricalSportOddsEndpoint = "/v4/historical/sports/{sport}/odds";
  
  private readonly IRestClient _client;

  public HistoricalClient(IRestClient client)
  {
    this._client = client;
  }

  /// <inheritdoc/>
  public async Task<List<HistoricalEvents>> RetrieveHistoricalSportEventsAsync(RetrieveHistoricalSportEventsRequest request, CancellationToken cancellation = default)
  {
    cancellation.ThrowIfCancellationRequested();

    var restRequest = request.ToRestRequest();
    var response = await this._client.ExecuteAsync<List<HistoricalEvents>>(restRequest, cancellation);
     if (response.IsSuccessful) return response.Data!;
    
    throw this._client.BuildExceptionFromResponse(response);
  }

  /// <inheritdoc/>
  public async Task<HistoricalEventOdds> RetrieveHistoricalSportEventOddsAsync(RetrieveHistoricalSportEventOddsRequest request, CancellationToken cancellation = default)
  {
    cancellation.ThrowIfCancellationRequested();
    
    var restRequest = request.ToRestRequest();
    var response = await this._client.ExecuteAsync<HistoricalEventOdds>(restRequest, cancellation);
    if (response.IsSuccessful) return response.Data!;
    
    throw this._client.BuildExceptionFromResponse(response);
  }

  /// <inheritdoc/>
  public async Task<HistoricalSportOdds> RetrieveHistoricalSportOddsAsync(RetrieveHistoricalSportOddsRequest request, CancellationToken cancellation = default)
  {
    cancellation.ThrowIfCancellationRequested();
  
    var restRequest = request.ToRestRequest();
    var response = await this._client.ExecuteAsync<HistoricalSportOdds>(restRequest, cancellation);
    if (response.IsSuccessful) return response.Data!;
    
    throw this._client.BuildExceptionFromResponse(response);
  }
}