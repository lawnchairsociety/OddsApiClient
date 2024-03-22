using OddsApiClient.Models;

namespace OddsApiClient.Responses;
public class RetrieveSportsResponse
    : Response
{
    public List<Sport> Sports { get; set; } = [];
}
