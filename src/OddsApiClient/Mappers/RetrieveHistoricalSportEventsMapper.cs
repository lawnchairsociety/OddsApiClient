using System.Globalization;
using OddsApiClient.Requests;
using RestSharp;

namespace OddsApiClient.Mappers;

internal static class RetrieveHistoricalSportEventsMapper
{
    public static RestRequest ToRestRequest(this RetrieveHistoricalSportEventsRequest request)
    {
        var restRequest = new RestRequest(HistoricalClient.HistoricalSportEventsEndpoint)
          .AddUrlSegment("sport", request.Sport)
          .AddQueryParameter("date", request.Date.ToString("yyyy-MM-ddTHH:mm:ssZ", CultureInfo.InvariantCulture), false)
          .AddQueryParameter("dateFormat", request.DateFormat);
        restRequest.Method = Method.Get;

        if (!string.IsNullOrEmpty(request.EventIds))
            restRequest.AddQueryParameter("eventIds", request.EventIds);
        if (request.CommenceTimeFrom.HasValue)
            restRequest.AddQueryParameter("commenceTimeFrom", request.CommenceTimeFrom.Value.ToString("yyyy-MM-ddTHH:mm:ssZ", CultureInfo.InvariantCulture), false);
        if (request.CommenceTimeTo.HasValue)
            restRequest.AddQueryParameter("commenceTimeTo", request.CommenceTimeTo.Value.ToString("yyyy-MM-ddTHH:mm:ssZ", CultureInfo.InvariantCulture), false);

        return restRequest;
    }
}
