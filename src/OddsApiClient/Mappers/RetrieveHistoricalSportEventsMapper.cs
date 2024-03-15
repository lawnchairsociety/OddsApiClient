using OddsApiClient.Requests;
using RestSharp;

namespace OddsApiClient.Mappers;

internal static class RetrieveHistoricalSportEventsMapper
{
  public static RestRequest ToRestRequest(this RetrieveHistoricalSportEventsRequest request)
    => new RestRequest(OddsClient.HistoricalSportEventsEndpoint, Method.Get);
}