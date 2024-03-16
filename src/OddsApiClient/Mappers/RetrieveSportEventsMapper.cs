using System.Globalization;
using OddsApiClient.Requests;
using RestSharp;

namespace OddsApiClient.Mappers;

internal static class RetrieveSportEventsMapper
{
  public static RestRequest ToRestRequest(this RetrieveSportEventsRequest request)
  {
    var req = new RestRequest(OddsClient.SportEventsEndpoint, Method.Get)
        .AddUrlSegment("sport", request.Sport)
        .AddQueryParameter("dateFormat", request.DateFormat);
    
    if (!String.IsNullOrEmpty(request.EventIds))
      req.AddQueryParameter("eventIds", request.EventIds);
    
    if (request.CommenceTimeFrom.HasValue)
      req.AddQueryParameter("commenceTimeFrom", request.CommenceTimeFrom.Value.ToString("yyyy-MM-ddTHH:mm:ssZ", CultureInfo.InvariantCulture), false);
    
    if (request.CommenceTimeTo.HasValue)
      req.AddQueryParameter("commenceTimeTo", request.CommenceTimeTo.Value.ToString("yyyy-MM-ddTHH:mm:ssZ", CultureInfo.InvariantCulture), false);
    
    return req;
  }
}