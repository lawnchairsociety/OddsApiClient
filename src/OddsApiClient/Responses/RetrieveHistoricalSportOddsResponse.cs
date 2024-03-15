namespace OddsApiClient.Responses;

public class RetrieveHistoricalSportOddsResponse
{
  /// <summary>
  /// A list of live and upcoming events at a point in time for a given sport, including bookmaker odds for the specified region and markets.
  /// </summary>
  public Models.HistoricalSportOdds HistoricalSportOdds { get; set; } = default!;
}