namespace OddsApiClient.Requests;

public class RetrieveHistoricalSportEventsRequest
{
    public string Sport { get; set; } = string.Empty;

    public string DateFormat { get; set; } = "iso";

    public string EventIds { get; set; } = string.Empty;

    public DateTime? CommenceTimeFrom { get; set; }

    public DateTime? CommenceTimeTo { get; set; }

    public DateTime Date { get; set; } = DateTime.UtcNow;
}
