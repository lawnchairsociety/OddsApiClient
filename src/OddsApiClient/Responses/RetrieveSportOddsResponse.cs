namespace OddsApiClient.Responses;

public class RetrieveSportOddsResponse
{
  /// <summary>
  /// A list of live and upcoming events for a given sport, showing bookmaker odds for the specified region and markets.
  /// </summary>
  public List<Models.Odds> Odds { get; set; } = default!;
}