using OddsApiClient.Requests;
using RestSharp;

namespace OddsApiClient.Mappers;

internal static class RetrieveHistoricalSportEventsMapper
{
  public static RestRequest ToRestRequest(this RetrieveHistoricalSportEventsRequest request)
  {
    var req = new RestRequest(OddsClient.HistoricalSportEventsEndpoint, Method.Get)
      .AddUrlSegment("sport", request.Sport)
      .AddQueryParameter("date", request.Date.ToString("s"))
      .AddQueryParameter("dateFormat", request.DateFormat);
    
    if (!String.IsNullOrEmpty(request.EventIds))
      req.AddQueryParameter("eventIds", request.EventIds);
    if (request.CommenceTimeFrom.HasValue)
      req.AddQueryParameter("commenceTimeFrom", request.CommenceTimeFrom.Value.ToString("s"));
    if (request.CommenceTimeTo.HasValue)
      req.AddQueryParameter("commenceTimeTo", request.CommenceTimeTo.Value.ToString("s"));
    
    return req;
  }
}