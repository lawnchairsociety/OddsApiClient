using System.Globalization;
using OddsApiClient.Requests;
using RestSharp;

namespace OddsApiClient.Mappers;

internal static class RetrieveHistoricalSportOddsMapper
{
  public static RestRequest ToRestRequest(this RetrieveHistoricalSportOddsRequest request)
  {
    var restRequest = new RestRequest(HistoricalClient.HistoricalSportOddsEndpoint)
      .AddUrlSegment("sport", request.Sport)
      .AddQueryParameter("regions", request.Regions)
      .AddQueryParameter("date", request.Date.ToString("yyyy-MM-ddTHH:mm:ssZ", CultureInfo.InvariantCulture), false)
      .AddQueryParameter("markets", request.Markets)
      .AddQueryParameter("dateFormat", request.DateFormat)
      .AddQueryParameter("oddsFormat", request.OddsFormat);
    restRequest.Method = Method.Get;
    
    if (!string.IsNullOrEmpty(request.EventIds))
      restRequest.AddQueryParameter("eventIds", request.EventIds);
    
    if (!string.IsNullOrEmpty(request.Bookmakers))
      restRequest.AddQueryParameter("bookmakers", request.Bookmakers);
    
    return restRequest;
  }
}