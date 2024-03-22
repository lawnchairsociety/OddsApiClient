using System.Globalization;
using OddsApiClient.Requests;
using RestSharp;

namespace OddsApiClient.Mappers;

internal static class RetrieveSportEventsMapper
{
    public static RestRequest ToRestRequest(this RetrieveSportEventsRequest request)
    {
        var restRequest = new RestRequest(EventsClient.SportEventsEndpoint)
          .AddUrlSegment("sport", request.Sport)
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
