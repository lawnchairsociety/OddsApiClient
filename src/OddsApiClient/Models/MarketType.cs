namespace OddsApiClient.Models;

public enum MarketType
{
  /// <summary>
  /// Unknown/default market type.
  /// </summary>
  Unknown,

  /// <summary>
  /// Head to head market type.
  /// </summary>
  H2H,

  /// <summary>
  /// Spreads market type.
  /// </summary>
  Spreads,

  /// <summary>
  /// Totals market type.
  /// </summary>
  Totals,

  /// <summary>
  /// Outrights market type.
  /// </summary>
  Outrights
}