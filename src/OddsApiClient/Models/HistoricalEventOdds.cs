namespace OddsApiClient.Models;

public class HistoricalEventOdds
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
  /// The odds data for a specific event.
  /// </summary>
  public Odds? Data { get; set; } = null;
}