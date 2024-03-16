using OddsApiClient.Requests;
using RestSharp;

namespace OddsApiClient.Mappers;

internal static class RetrieveSportsMapper
{
  public static RestRequest ToRestRequest(this RetrieveSportsRequest request)
  {
    var req = new RestRequest(OddsClient.SportsEndpoint, Method.Get)
        .AddParameter("all", request.All ? "true":"false");
    
    return req;
  }
}