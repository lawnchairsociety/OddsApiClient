namespace OddsApiClient.Models;

public class HistoricalSportOdds
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
  /// A list of live and upcoming events at the time of the snapshot.
  /// </summary>
  public List<Odds> Data { get; set; } = [];
}