using OddsApiClient.Requests;
using RestSharp;

namespace OddsApiClient.Mappers;

internal static class RetrieveSportOddsMapper
{
  public static RestRequest ToRestRequest(this RetrieveSportOddsRequest request)
  {
    var req = new RestRequest(OddsClient.SportOddsEndpoint, Method.Get)
        .AddUrlSegment("sport", request.Sport)
        .AddQueryParameter("regions", request.Regions)
        .AddQueryParameter("markets", request.Markets)
        .AddQueryParameter("dateFormat", request.DateFormat)
        .AddQueryParameter("oddsFormat", request.OddsFormat);
    
    if (!String.IsNullOrEmpty(request.EventIds))
      req.AddQueryParameter("eventIds", request.EventIds);
    
    if (!String.IsNullOrEmpty(request.Bookmakers))
      req.AddQueryParameter("bookmakers", request.Bookmakers);

    if (request.CommenceTimeFrom.HasValue)
      req.AddQueryParameter("commenceTimeFrom", request.CommenceTimeFrom.Value.ToString("s"));
    if (request.CommenceTimeTo.HasValue)
      req.AddQueryParameter("commenceTimeTo", request.CommenceTimeTo.Value.ToString("s"));

    return req;
  }
}