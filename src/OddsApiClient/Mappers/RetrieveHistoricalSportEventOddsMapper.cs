using System.Globalization;
using OddsApiClient.Requests;
using RestSharp;

namespace OddsApiClient.Mappers;

internal static class RetrieveHistoricalSportEventOddsMapper
{
  public static RestRequest ToRestRequest(this RetrieveHistoricalSportEventOddsRequest request)
  {
    var restRequest = new RestRequest(HistoricalClient.HistoricalSportEventOddsEndpoint)
      .AddUrlSegment("sport", request.Sport)
      .AddUrlSegment("eventId", request.EventId)
      .AddQueryParameter("regions", request.Regions)
      .AddQueryParameter("date", request.Date.ToString("yyyy-MM-ddTHH:mm:ssZ", CultureInfo.InvariantCulture), false)
      .AddQueryParameter("markets", request.Markets)
      .AddQueryParameter("dateFormat", request.DateFormat)
      .AddQueryParameter("oddsFormat", request.OddsFormat);
    restRequest.Method = Method.Get;
    
    if (!string.IsNullOrEmpty(request.Bookmakers))
      restRequest.AddQueryParameter("bookmakers", request.Bookmakers);
    
    return restRequest;
  }
}