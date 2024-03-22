using System.Text.Json.Serialization;

namespace OddsApiClient.Models;

public class Event
{
  /// <summary>
  /// A unique 32 character identifier for the event.
  /// </summary>
  public string Id { get; set; } = string.Empty;

  /// <summary>
  /// A unique slug for the sport.
  /// </summary>
  [JsonPropertyName("sport_key")]
  public string SportKey { get; set; } = string.Empty;

  /// <summary>
  /// A presentable title of the sport.
  /// </summary>
  [JsonPropertyName("sport_title")]
  public string SportTitle { get; set; } = string.Empty;

  /// <summary>
  /// The match start time.
  /// </summary>
  [JsonPropertyName("commence_time")]
  public DateTime? CommenceTime { get; set; }

  /// <summary>
  /// The home team. If home/away is not applicable for the sport (such as MMA and Tennis), it will be one of the participants.
  /// </summary>
  [JsonPropertyName("home_team")]
  public string HomeTeam { get; set; } = string.Empty;

  /// <summary>
  /// The away team. If home/away is not applicable for the sport (such as MMA and Tennis), it will be one of the participants.
  /// </summary>
  [JsonPropertyName("away_team")]
  public string AwayTeam { get; set; } = string.Empty;
}
