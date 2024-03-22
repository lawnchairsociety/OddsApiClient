using OddsApiClient.Requests;
using RestSharp;

namespace OddsApiClient.Mappers;

internal static class RetrieveSportsMapper
{
    public static RestRequest ToRestRequest(this RetrieveSportsRequest request)
    {
        var restRequest = new RestRequest(SportsClient.SportsEndpoint)
          .AddParameter("all", request.All ? "true" : "false");
        restRequest.Method = Method.Get;

        return restRequest;
    }
}
