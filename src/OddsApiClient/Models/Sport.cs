using System.Text.Json.Serialization;

namespace OddsApiClient.Models;

public class Sport
{
  /// <summary>
  /// A unique slug (key) for the sport.
  /// </summary>
  public string Key { get; set; } = string.Empty;

  /// <summary>
  /// A broader grouping (e.g. - 'American Football')
  /// </summary>
  public string Group { get; set; } = string.Empty;

  /// <summary>
  /// A presentable title of the sport.
  /// </summary>
  public string Title { get; set; } = string.Empty;

  /// <summary>
  /// A brief description of the sport.
  /// </summary>
  public string Description { get; set; } = string.Empty;
  
  /// <summary>
  /// Indicates if the sport is in season.
  /// </summary>
  public bool Active { get; set; } = false;

  /// <summary>
  /// Indicates if the sport has outrights markets.
  /// </summary>
  [JsonPropertyName("has_outrights")]
  public bool HasOutrights { get; set; } = false;
}
