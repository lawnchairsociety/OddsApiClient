namespace OddsApiClient.Models;

public class HistoricalEvents
{
  /// <summary>
  /// The timestamp of the snapshot.
  /// </summary>
  public DateTime Timestamp { get; set; } = DateTime.Now;

  /// <summary>
  /// The preceding available timestamp.
  /// </summary>
  public DateTime PreviousTimestamp { get; set; } = DateTime.Now;

  /// <summary>
  /// The next available timestamp.
  /// </summary>
  public DateTime NextTimestamp { get; set; } = DateTime.Now;

  /// <summary>
  /// A list of live and upcoming events.
  /// </summary>
  public List<Event> Data { get; set; } = [];
}