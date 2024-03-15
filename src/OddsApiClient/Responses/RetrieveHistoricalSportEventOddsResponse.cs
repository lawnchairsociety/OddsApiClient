namespace OddsApiClient.Responses;

public class RetrieveHistoricalSportEventOddsResponse
{
  /// <summary>
  /// Odds for a single event as they appeared at the specified timestamp;
  /// </summary>
  public Models.HistoricalEventOdds HistoricalEventOdds { get; set; } = default!;
}