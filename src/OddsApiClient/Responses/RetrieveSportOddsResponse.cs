using OddsApiClient.Models;

namespace OddsApiClient.Responses;
public class RetrieveSportOddsResponse
    : Response
{
    public List<Odds> Odds { get; set; } = [];
}
