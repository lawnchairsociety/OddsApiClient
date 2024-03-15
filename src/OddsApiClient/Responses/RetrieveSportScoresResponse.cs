namespace OddsApiClient.Responses;

public class RetrieveSportScoresResponse
{
  /// <summary>
  /// A list of live and upcoming events for a given sport, and optionally recently completed events.
  /// </summary>
  public List<Models.SportScores> Scores { get; set; } = default!;
}