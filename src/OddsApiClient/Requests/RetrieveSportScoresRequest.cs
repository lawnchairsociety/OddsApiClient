namespace OddsApiClient.Requests;

public class RetrieveSportScoresRequest
{
  public string Sport { get; set; } = string.Empty;

  public int? DaysFrom { get; set; }

  public string DateFormat { get; set; } = "iso";

  public string EventIds { get; set; } = string.Empty;
}