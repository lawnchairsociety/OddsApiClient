using OddsApiClient.Models;

namespace OddsApiClient.Responses;
public class RetrieveHistoricalSportOddsResponse
    : Response
{
    public HistoricalSportOdds HistoricalSportOdds { get; set; }
}
