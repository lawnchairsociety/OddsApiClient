using OddsApiClient.Requests;
using RestSharp;

namespace OddsApiClient.Mappers;

internal static class RetrieveHistoricalSportOddsMapper
{
  public static RestRequest ToRestRequest(this RetrieveHistoricalSportOddsRequest request)
    => new RestRequest(OddsClient.SportEventOddsEndpoint, Method.Get);
}