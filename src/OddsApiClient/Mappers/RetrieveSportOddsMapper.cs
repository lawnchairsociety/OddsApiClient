using OddsApiClient.Requests;
using RestSharp;

namespace OddsApiClient.Mappers;

internal static class RetrieveSportOddsMapper
{
  public static RestRequest ToRestRequest(this RetrieveSportOddsRequest request)
    => new RestRequest(OddsClient.SportOddsEndpoint, Method.Get);
}