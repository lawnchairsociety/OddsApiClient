using OddsApiClient.Models;

namespace OddsApiClient.Responses;
public class RetrieveSportEventOddsResponse
    : Response
{
    public Odds EventOdds { get; set; }
}
