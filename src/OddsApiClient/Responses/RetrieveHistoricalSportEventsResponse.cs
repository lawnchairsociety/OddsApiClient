using OddsApiClient.Models;

namespace OddsApiClient.Responses;
public class RetrieveHistoricalSportEventsResponse
    : Response
{
    public HistoricalEvents HistoricalSportEvents { get; set; }
}
