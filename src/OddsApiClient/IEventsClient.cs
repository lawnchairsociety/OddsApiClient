using OddsApiClient.Exceptions;
using OddsApiClient.Extensions;
using OddsApiClient.Mappers;
using OddsApiClient.Models;
using OddsApiClient.Requests;
using OddsApiClient.Responses;
using RestSharp;

namespace OddsApiClient;

public interface IEventsClient
{
    /// <summary>
    /// Retrieves in-play and pre-match events for a specified sport or league. Odds are not included in the response. This endpoint does not count against the usage quota.
    /// </summary>
    /// <param name="request">The request.</param>
    /// <param name="cancellation">The token used to cancel the operation.</param>
    /// <returns>The response.</returns>
    /// <exception cref="OddsApiClientUnauthorizedException"></exception>
    /// <exception cref="OddsApiClientInvalidParameterException"></exception>
    /// <exception cref="OddsApiClientTooManyRequestsException"></exception>
    /// <exception cref="OddsApiClientInternalErrorException"></exception>
    Task<RetrieveSportEventsResponse> RetrieveSportEventsAsync(RetrieveSportEventsRequest request, CancellationToken cancellation = default);

    /// <summary>
    /// Retrieves bookmaker odds for a single event as long as the event is still valid (live or upcoming).
    /// </summary>
    /// <param name="request">The request.</param>
    /// <param name="cancellation">The token used to cancel the operation.</param>
    /// <returns>The response.</returns>
    /// <exception cref="OddsApiClientUnauthorizedException"></exception>
    /// <exception cref="OddsApiClientNotFoundException"></exception>
    /// <exception cref="OddsApiClientInvalidParameterException"></exception>
    /// <exception cref="OddsApiClientTooManyRequestsException"></exception>
    /// <exception cref="OddsApiClientInternalErrorException"></exception>
    Task<RetrieveSportEventOddsResponse> RetrieveSportEventOddsAsync(RetrieveSportEventOddsRequest request, CancellationToken cancellation = default);

    /// <summary>
    /// Retrieves all live and upcoming events for a given sport, and optionally recently completed events. Live and completed events will contain scores.
    /// </summary>
    /// <param name="request">The request.</param>
    /// <param name="cancellation">The token used to cancel the operation.</param>
    /// <returns>The response.</returns>
    /// <exception cref="OddsApiClientUnauthorizedException"></exception>
    /// <exception cref="OddsApiClientInvalidParameterException"></exception>
    /// <exception cref="OddsApiClientTooManyRequestsException"></exception>
    /// <exception cref="OddsApiClientInternalErrorException"></exception>
    Task<RetrieveSportScoresResponse> RetrieveSportScoresAsync(RetrieveSportScoresRequest request, CancellationToken cancellation = default);

    /// <summary>
    /// Retrieves all live and upcoming events for a given sport, showing bookmaker odds for the specified region and markets.
    /// </summary>
    /// <param name="request">The request.</param>
    /// <param name="cancellation">The token used to cancel the operation.</param>
    /// <returns>The response.</returns>
    /// <exception cref="OddsApiClientUnauthorizedException"></exception>
    /// <exception cref="OddsApiClientInvalidParameterException"></exception>
    /// <exception cref="OddsApiClientTooManyRequestsException"></exception>
    /// <exception cref="OddsApiClientInternalErrorException"></exception>
    Task<RetrieveSportOddsResponse> RetrieveSportOddsAsync(RetrieveSportOddsRequest request, CancellationToken cancellation = default);
}

public class EventsClient
  : IEventsClient
{
    internal const string SportEventsEndpoint = "/v4/sports/{sport}/events";
    internal const string SportEventOddsEndpoint = "/v4/sports/{sport}/events/{eventId}/odds";
    internal const string SportScoresEndpoint = "/v4/sports/{sport}/scores";
    internal const string SportOddsEndpoint = "/v4/sports/{sport}/odds";

    private readonly IRestClient _client;

    public EventsClient(IRestClient client)
    {
        this._client = client;
    }

    /// <inheritdoc/>
    public async Task<RetrieveSportEventsResponse> RetrieveSportEventsAsync(RetrieveSportEventsRequest request, CancellationToken cancellation = default)
    {
        cancellation.ThrowIfCancellationRequested();

        var restRequest = request.ToRestRequest();
        var response = await this._client.ExecuteAsync<List<Event>>(restRequest, cancellation);
        if (response.IsSuccessful)
        {
            _ = int.TryParse(this._client.GetHeaderValue(response, "x-requests-used"), out int used);
            _ = int.TryParse(this._client.GetHeaderValue(response, "x-requests-remaining"), out int remaining);
            return new RetrieveSportEventsResponse
            {
                RequestsUsed = used,
                RequestsRemaining = remaining,
                Events = response.Data!
            };
        }

        throw this._client.BuildExceptionFromResponse(response);
    }

    /// <inheritdoc/>
    public async Task<RetrieveSportEventOddsResponse> RetrieveSportEventOddsAsync(RetrieveSportEventOddsRequest request, CancellationToken cancellation = default)
    {
        cancellation.ThrowIfCancellationRequested();

        var restRequest = request.ToRestRequest();
        var response = await this._client.ExecuteAsync<Odds>(restRequest, cancellation);
        if (response.IsSuccessful)
        {
            _ = int.TryParse(this._client.GetHeaderValue(response, "x-requests-used"), out int used);
            _ = int.TryParse(this._client.GetHeaderValue(response, "x-requests-remaining"), out int remaining);
            return new RetrieveSportEventOddsResponse
            {
                RequestsUsed = used,
                RequestsRemaining = remaining,
                EventOdds = response.Data!
            };
        }

        throw this._client.BuildExceptionFromResponse(response);
    }

    /// <inheritdoc/>
    public async Task<RetrieveSportScoresResponse> RetrieveSportScoresAsync(RetrieveSportScoresRequest request, CancellationToken cancellation = default)
    {
        cancellation.ThrowIfCancellationRequested();
        var restRequest = request.ToRestRequest();
        var response = await this._client.ExecuteAsync<List<SportScores>>(restRequest, cancellation);

        if (response.IsSuccessful)
        {
            _ = int.TryParse(this._client.GetHeaderValue(response, "x-requests-used"), out int used);
            _ = int.TryParse(this._client.GetHeaderValue(response, "x-requests-remaining"), out int remaining);
            return new RetrieveSportScoresResponse
            {
                RequestsUsed = used,
                RequestsRemaining = remaining,
                Scores = response.Data!
            };
        }

        throw this._client.BuildExceptionFromResponse(response);
    }

    /// <inheritdoc/>
    public async Task<RetrieveSportOddsResponse> RetrieveSportOddsAsync(RetrieveSportOddsRequest request, CancellationToken cancellation = default)
    {
        cancellation.ThrowIfCancellationRequested();

        var restRequest = request.ToRestRequest();
        var response = await this._client.ExecuteAsync<List<Odds>>(restRequest, cancellation);
        if (response.IsSuccessful)
        {
            _ = int.TryParse(this._client.GetHeaderValue(response, "x-requests-used"), out int used);
            _ = int.TryParse(this._client.GetHeaderValue(response, "x-requests-remaining"), out int remaining);
            return new RetrieveSportOddsResponse
            {
                RequestsUsed = used,
                RequestsRemaining = remaining,
                Odds = response.Data!
            };
        }

        throw this._client.BuildExceptionFromResponse(response);
    }
}
