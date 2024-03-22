using OddsApiClient.Requests;
using RestSharp;

namespace OddsApiClient.Mappers;

internal static class RetrieveSportEventOddsMapper
{
  public static RestRequest ToRestRequest(this RetrieveSportEventOddsRequest request)
  {
    var restRequest = new RestRequest(EventsClient.SportEventOddsEndpoint)
      .AddUrlSegment("sport", request.Sport)
      .AddUrlSegment("eventId", request.EventId)
      .AddQueryParameter("regions", request.Regions)
      .AddQueryParameter("markets", request.Markets)
      .AddQueryParameter("oddsFormat", request.OddsFormat)
      .AddQueryParameter("dateFormat", request.DateFormat);
    restRequest.Method = Method.Get;
    
    if (!string.IsNullOrEmpty(request.Bookmakers))
      restRequest.AddQueryParameter("bookmakers", request.Bookmakers);
    
    return restRequest;
  }
}