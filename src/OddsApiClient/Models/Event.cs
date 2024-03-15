namespace OddsApiClient.Models;

public class Event
{
  /// <summary>
  /// A unique 32 character identifier for the event.
  /// </summary>
  public string Id { get; set; } = String.Empty;

  /// <summary>
  /// A unique slug for the sport.
  /// </summary>
  public string SportKey { get; set; } = String.Empty;

  /// <summary>
  /// A presentable title of the sport.
  /// </summary>
  public string SportTitle { get; set; } = String.Empty;

  /// <summary>
  /// The match start time.
  /// </summary>
  public DateTime CommenceTime { get; set; } = DateTime.UtcNow;

  /// <summary>
  /// The home team. If home/away is not applicable for the sport (such as MMA and Tennis), it will be one of the participants.
  /// </summary>
  public string HomeTeam { get; set; } = String.Empty;

  /// <summary>
  /// The away team. If home/away is not applicable for the sport (such as MMA and Tennis), it will be one of the participants.
  /// </summary>
  public string AwayTeam { get; set; } = String.Empty;
}