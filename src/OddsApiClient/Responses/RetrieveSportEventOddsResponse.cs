namespace OddsApiClient.Responses;

public class RetrieveSportEventOddsResponse
{
  /// <summary>
  /// The event with the eventId specified in the path parameter. Includes odds from bookmakers in the specified region for the specified markets.
  /// </summary>
  public Models.Odds EventOdds { get; set; } = default!;
}