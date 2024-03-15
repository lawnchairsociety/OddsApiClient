namespace OddsApiClient.Models;

public class Sport
{
  /// <summary>
  /// A unique slug (key) for the sport.
  /// </summary>
  public string Key { get; set; } = String.Empty;

  /// <summary>
  /// Indicates if the sport is in season.
  /// </summary>
  public bool Active { get; set; } = false;

  /// <summary>
  /// A broader grouping (e.g. - 'American Football')
  /// </summary>
  public string Group { get; set; } = String.Empty;

  /// <summary>
  /// A brief description of the sport.
  /// </summary>
  public string Description { get; set; } = String.Empty;

  /// <summary>
  /// A presentable title of the sport.
  /// </summary>
  public string Title { get; set; } = String.Empty;

  /// <summary>
  /// Indicates if the sport has outrights markets.
  /// </summary>
  public bool HasOutrights { get; set; } = false;
}
