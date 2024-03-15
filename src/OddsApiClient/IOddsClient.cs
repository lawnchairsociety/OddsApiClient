using OddsApiClient.Exceptions;
using OddsApiClient.Requests;
using OddsApiClient.Responses;

namespace OddsApiClient;

public interface IOddsClient
{
  /// <summary>
  /// Retrieves all available sports and tournaments.
  /// </summary>
  /// <param name="request">The request.</param>
  /// <param name="cancellation">The token used to cancel the operation.</param>
  /// <returns>The response.</returns>
  /// <exception cref="OddsApiClientUnauthorizedException"></exception>
  /// <exception cref="OddsApiClientInvalidParameterException"></exception>
  /// <exception cref="OddsApiClientTooManyRequestsException"></exception>
  /// <exception cref="OddsApiClientInternalErrorException"></exception>
  Task<RetrieveSportsResponse> RetrieveSportsAsync(RetrieveSportsRequest request, CancellationToken cancellation = default);

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
  Task<RetrieveSportScoresResponse> RetrieveSportScoresAsync(RetrieveSportScoresRequest request,CancellationToken cancellation = default);

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
  Task<RetrieveSportEventsResponse> RetrieveSportEventsAsync(RetrieveSportEventsRequest request,CancellationToken cancellation = default);

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
  Task<RetrieveSportOddsResponse> RetrieveSportOddsAsync(RetrieveSportOddsRequest request,CancellationToken cancellation = default);

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
  Task<RetrieveSportEventOddsResponse> RetrieveSportEventOddsAsync(RetrieveSportEventOddsRequest request,CancellationToken cancellation = default);

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
  Task<RetrieveHistoricalSportEventsResponse> RetrieveHistoricalSportEventsAsync(RetrieveHistoricalSportEventsRequest request,CancellationToken cancellation = default);

  /// <summary>
  /// Retrieves live and upcoming events at a point in time for a given sport, including bookmaker odds for the specified region and markets.
  /// </summary>
  /// <param name="request">The request.</param>
  /// <param name="cancellation">The token used to cancel the operation.</param>
  /// <returns>The response.</returns>
  /// <exception cref="OddsApiClientUnauthorizedException"></exception>
  /// <exception cref="OddsApiClientInvalidParameterException"></exception>
  /// <exception cref="OddsApiClientTooManyRequestsException"></exception>
  /// <exception cref="OddsApiClientInternalErrorException"></exception>
  Task<RetrieveHistoricalSportOddsResponse> RetrieveHistoricalSportOddsAsync(RetrieveHistoricalSportOddsRequest request,CancellationToken cancellation = default);

  /// <summary>
  /// Retrieves bookmaker odds for a single event as they appeared at the specified timestamp (date parameter).
  /// </summary>
  /// <param name="request">The request.</param>
  /// <param name="cancellation">The token used to cancel the operation.</param>
  /// <returns>The response.</returns>
  /// <exception cref="OddsApiClientUnauthorizedException"></exception>
  /// <exception cref="OddsApiClientNotFoundException"></exception>
  /// <exception cref="OddsApiClientInvalidParameterException"></exception>
  /// <exception cref="OddsApiClientTooManyRequestsException"></exception>
  /// <exception cref="OddsApiClientInternalErrorException"></exception>
  Task<RetrieveHistoricalSportEventOddsResponse> RetrieveHistoricalSportEventOddsAsync(RetrieveHistoricalSportEventOddsRequest request,CancellationToken cancellation = default);
}