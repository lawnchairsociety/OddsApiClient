namespace OddsApiClient.Responses;

public class RetrieveSportEventsResponse
{
  /// <summary>
  /// A list of in-play and pre-match events for a specified sport or league.
  /// </summary>
  public List<Models.Event> Events { get; set; } = default!;
}