namespace OddsApiClient.Requests;

public class RetrieveHistoricalSportOddsRequest
{
  public string Sport { get; set; } = String.Empty;

  public string Regions { get; set; } = "us";

  public string Markets { get; set; } = "h2h";

  public string DateFormat { get; set; } = "iso";

  public string OddsFormat { get; set; } = "decimal";

  public string EventIds { get; set; } = String.Empty;

  public string Bookmakers { get; set; } = String.Empty;

  public DateTime Date { get; set; } = DateTime.UtcNow;
}