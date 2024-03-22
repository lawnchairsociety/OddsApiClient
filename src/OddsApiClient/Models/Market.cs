using System.Text.Json.Serialization;

namespace OddsApiClient.Models;

public class Market
{
  /// <summary>
  /// The type of the odds market
  /// </summary>
  public string Key { get; set; } = string.Empty;

  /// <summary>
  /// A timestamp of when the markets' odds were last read
  /// </summary>
  [JsonPropertyName("last_update")]
  public DateTime? LastUpdate { get; set; }

  /// <summary>
  /// An ordered list of outcomes in a given market
  /// </summary>
  public List<Outcome>? Outcomes { get; set; }
}