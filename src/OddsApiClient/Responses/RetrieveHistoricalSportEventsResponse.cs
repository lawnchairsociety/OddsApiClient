namespace OddsApiClient.Responses;

public class RetrieveHistoricalSportEventsResponse
{
  /// <summary>
  /// A list of events for the specified sport as they appeared at the specified timestamp
  /// </summary>
  public Models.HistoricalEvents HistoricalEvents { get; set; } = default!;
}