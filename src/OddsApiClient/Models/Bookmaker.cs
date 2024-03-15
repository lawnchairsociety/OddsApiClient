namespace OddsApiClient.Models;

public class Bookmaker
{
  /// <summary>
  /// A unique slug (key) of the bookmaker.
  /// </summary>
  public string Key { get; set; } = String.Empty;

  /// <summary>
  /// A formatted title of the bookmaker.
  /// </summary>
  public string Title { get; set; } = String.Empty;

  /// <summary>
  /// A timestamp of when the bookmaker's odds were last read.
  /// </summary>
  public DateTime LastUpdate { get; set; } = DateTime.UtcNow;

  /// <summary>
  /// A list of markets for the given bookmaker.
  /// </summary>
  public List<Market> Markets { get; set; } = [];
}