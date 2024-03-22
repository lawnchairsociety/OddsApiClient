using OddsApiClient.Models;

namespace OddsApiClient.Responses;
public class RetrieveSportEventsResponse
    : Response
{
    public List<Event> Events { get; set; } = [];
}
