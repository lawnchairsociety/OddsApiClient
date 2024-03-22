using OddsApiClient.Models;

namespace OddsApiClient.Responses;
public class RetrieveSportScoresResponse
    : Response
{
    public List<SportScores> Scores { get; set; } = [];
}
