namespace OddsApiClient.Requests;

public class RetrieveSportEventOddsRequest
{
  public string Sport { get; set; } = String.Empty;

  public string EventId { get; set; } = String.Empty;

  public string Regions { get; set; } = "us";

  public string Markets { get; set; } = "h2h";

  public string DateFormat { get; set; } = "iso";

  public string OddsFormat { get; set; } = "decimal";

  public string Bookmakers { get; set; } = String.Empty;
}