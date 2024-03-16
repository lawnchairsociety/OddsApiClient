using OddsApiClient.Requests;
using RestSharp;

namespace OddsApiClient.Mappers;

internal static class RetrieveSportScoresMapper
{
  public static RestRequest ToRestRequest(this RetrieveSportScoresRequest request)
  {
    var req = new RestRequest(OddsClient.SportScoresEndpoint, Method.Get)
        .AddUrlSegment("sport", request.Sport)
        .AddQueryParameter("dateFormat", request.DateFormat);
    
    if (request.DaysFrom.HasValue)
      req.AddQueryParameter("daysFrom", request.DaysFrom.Value);
    if (!String.IsNullOrEmpty(request.EventIds))
      req.AddQueryParameter("eventIds", request.EventIds);
    
    return req;
  }
}