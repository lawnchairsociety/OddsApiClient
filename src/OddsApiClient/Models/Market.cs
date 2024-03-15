namespace OddsApiClient.Models;

public class Market
{
  /// <summary>
  /// The type of the odds market
  /// </summary>
  public MarketType Key { get; set; } = MarketType.Unknown;

  /// <summary>
  /// A timestamp of when the markets' odds were last read
  /// </summary>
  public DateTime LastUpdate { get; set; } = DateTime.UtcNow;

  /// <summary>
  /// An ordered list of outcomes in a given market
  /// </summary>
  public List<Outcome> Outcomes { get; set; } = [];
}