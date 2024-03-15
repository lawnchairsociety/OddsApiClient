using OddsApiClient.Requests;
using RestSharp;

namespace OddsApiClient.Mappers;

internal static class RetrieveSportEventOddsMapper
{
  public static RestRequest ToRestRequest(this RetrieveSportEventOddsRequest request)
    => new RestRequest(OddsClient.SportOddsEndpoint, Method.Get);
}