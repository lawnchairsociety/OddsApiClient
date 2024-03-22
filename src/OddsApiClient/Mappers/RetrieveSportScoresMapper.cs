using OddsApiClient.Requests;
using RestSharp;

namespace OddsApiClient.Mappers;

internal static class RetrieveSportScoresMapper
{
    public static RestRequest ToRestRequest(this RetrieveSportScoresRequest request)
    {
        var restRequest = new RestRequest(EventsClient.SportScoresEndpoint)
          .AddUrlSegment("sport", request.Sport)
          .AddQueryParameter("dateFormat", request.DateFormat);
        restRequest.Method = Method.Get;

        if (request.DaysFrom.HasValue)
            restRequest.AddQueryParameter("daysFrom", request.DaysFrom.Value);
        if (!string.IsNullOrEmpty(request.EventIds))
            restRequest.AddQueryParameter("eventIds", request.EventIds);

        return restRequest;
    }
}
