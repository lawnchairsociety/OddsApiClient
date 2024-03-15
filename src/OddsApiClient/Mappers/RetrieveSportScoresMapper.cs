using OddsApiClient.Requests;
using RestSharp;

namespace OddsApiClient.Mappers;

internal static class RetrieveSportScoresMapper
{
  public static RestRequest ToRestRequest(this RetrieveSportScoresRequest request)
    => new RestRequest(OddsClient.SportScoresEndpoint, Method.Get);
}