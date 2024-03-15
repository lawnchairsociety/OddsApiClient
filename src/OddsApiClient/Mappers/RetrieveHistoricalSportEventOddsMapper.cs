using OddsApiClient.Requests;
using RestSharp;

namespace OddsApiClient.Mappers;

internal static class RetrieveHistoricalSportEventOddsMapper
{
  public static RestRequest ToRestRequest(this RetrieveHistoricalSportEventOddsRequest request)
    => new RestRequest(OddsClient.HistoricalSportEventOddsEndpoint, Method.Get);
}