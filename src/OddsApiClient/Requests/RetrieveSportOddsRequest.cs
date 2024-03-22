namespace OddsApiClient.Requests;

public class RetrieveSportOddsRequest
{

    public string Sport { get; set; } = string.Empty;

    public string Regions { get; set; } = "us";

    public string Markets { get; set; } = "h2h";

    public string DateFormat { get; set; } = "iso";

    public string OddsFormat { get; set; } = "decimal";

    public string EventIds { get; set; } = string.Empty;

    public string Bookmakers { get; set; } = string.Empty;

    public DateTime? CommenceTimeFrom { get; set; }

    public DateTime? CommenceTimeTo { get; set; }
}
