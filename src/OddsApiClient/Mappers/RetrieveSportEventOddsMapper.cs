using OddsApiClient.Requests;
using RestSharp;

namespace OddsApiClient.Mappers;

internal static class RetrieveSportEventOddsMapper
{
  public static RestRequest ToRestRequest(this RetrieveSportEventOddsRequest request)
  {
    var req = new RestRequest(OddsClient.SportOddsEndpoint, Method.Get)
      .AddUrlSegment("sport", request.Sport)
      .AddUrlSegment("eventId", request.EventId)
      .AddQueryParameter("regions", request.Regions)
      .AddQueryParameter("markets", request.Markets)
      .AddQueryParameter("oddsFormat", request.OddsFormat);
    
    if (!String.IsNullOrEmpty(request.Bookmakers))
      req.AddQueryParameter("bookmakers", request.Bookmakers);
    
    return req;
  }
}