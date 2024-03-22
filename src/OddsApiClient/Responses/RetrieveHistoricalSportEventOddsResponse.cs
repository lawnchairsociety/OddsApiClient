using OddsApiClient.Models;

namespace OddsApiClient.Responses;
public class RetrieveHistoricalSportEventOddsResponse
    : Response
{
    public HistoricalEventOdds HistoricalEventOdds { get; set; }
}
