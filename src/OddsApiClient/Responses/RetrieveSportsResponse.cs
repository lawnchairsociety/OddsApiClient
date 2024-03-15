namespace OddsApiClient.Responses;

public class RetrieveSportsResponse
{
  /// <summary>
  /// A list of available sports.
  /// </summary>
  public List<Models.Sport> Sports { get; set; } = default!;
}