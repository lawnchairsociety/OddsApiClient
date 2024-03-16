using OddsApiClient.Requests;
using RestSharp;

namespace OddsApiClient.Mappers;

internal static class RetrieveHistoricalSportEventOddsMapper
{
  public static RestRequest ToRestRequest(this RetrieveHistoricalSportEventOddsRequest request)
  {
    var req = new RestRequest(OddsClient.HistoricalSportEventOddsEndpoint, Method.Get)
      .AddUrlSegment("sport", request.Sport)
      .AddUrlSegment("eventId", request.EventId)
      .AddQueryParameter("regions", request.Regions)
      .AddQueryParameter("date", request.Date.ToString("s"))
      .AddQueryParameter("markets", request.Markets)
      .AddQueryParameter("dateFormat", request.DateFormat)
      .AddQueryParameter("oddsFormat", request.OddsFormat);
    
    if (!String.IsNullOrEmpty(request.Bookmakers))
      req.AddQueryParameter("bookmakers", request.Bookmakers);
    
    return req;
  }
}