namespace OddsApiClient.Requests;

public class RetrieveSportEventsRequest
{
  public string Sport { get; set; } = String.Empty;

  public string DateFormat { get; set; } = "iso";

  public string EventIds { get; set; } = String.Empty;

  public DateTime? CommenceTimeFrom { get; set; }

  public DateTime? CommenceTimeTo { get; set; }
}