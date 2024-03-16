using OddsApiClient.Requests;
using RestSharp;

namespace OddsApiClient.Mappers;

internal static class RetrieveSportsMapper
{
  public static RestRequest ToRestRequest(this RetrieveSportsRequest request)
    => new RestRequest(OddsClient.SportsEndpoint, Method.Get)
        .AddQueryParameter("all", request.All);
}