using System.Globalization;
using OddsApiClient.Requests;
using RestSharp;

namespace OddsApiClient.Mappers;

internal static class RetrieveSportOddsMapper
{
    public static RestRequest ToRestRequest(this RetrieveSportOddsRequest request)
    {
        var restRequest = new RestRequest(EventsClient.SportOddsEndpoint)
          .AddUrlSegment("sport", request.Sport)
          .AddQueryParameter("regions", request.Regions)
          .AddQueryParameter("markets", request.Markets)
          .AddQueryParameter("dateFormat", request.DateFormat)
          .AddQueryParameter("oddsFormat", request.OddsFormat);
        restRequest.Method = Method.Get;

        if (!string.IsNullOrEmpty(request.EventIds))
            restRequest.AddQueryParameter("eventIds", request.EventIds);

        if (!string.IsNullOrEmpty(request.Bookmakers))
            restRequest.AddQueryParameter("bookmakers", request.Bookmakers);

        if (request.CommenceTimeFrom.HasValue)
            restRequest.AddQueryParameter("commenceTimeFrom", request.CommenceTimeFrom.Value.ToString("yyyy-MM-ddTHH:mm:ssZ", CultureInfo.InvariantCulture), false);
        if (request.CommenceTimeTo.HasValue)
            restRequest.AddQueryParameter("commenceTimeTo", request.CommenceTimeTo.Value.ToString("yyyy-MM-ddTHH:mm:ssZ", CultureInfo.InvariantCulture), false);

        return restRequest;
    }
}
