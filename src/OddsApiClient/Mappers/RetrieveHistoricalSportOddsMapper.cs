using System.Globalization;
using OddsApiClient.Requests;
using RestSharp;

namespace OddsApiClient.Mappers;

internal static class RetrieveHistoricalSportOddsMapper
{
  public static RestRequest ToRestRequest(this RetrieveHistoricalSportOddsRequest request)
  {
    var req = new RestRequest(OddsClient.HistoricalSportOddsEndpoint, Method.Get)
      .AddUrlSegment("sport", request.Sport)
      .AddQueryParameter("regions", request.Regions)
      .AddQueryParameter("date", request.Date.ToString("yyyy-MM-ddTHH:mm:ssZ", CultureInfo.InvariantCulture), false)
      .AddQueryParameter("markets", request.Markets)
      .AddQueryParameter("dateFormat", request.DateFormat)
      .AddQueryParameter("oddsFormat", request.OddsFormat);
    
    if (!String.IsNullOrEmpty(request.EventIds))
      req.AddQueryParameter("eventIds", request.EventIds);
    
    if (!String.IsNullOrEmpty(request.Bookmakers))
      req.AddQueryParameter("bookmakers", request.Bookmakers);
    
    return req;
  }
}