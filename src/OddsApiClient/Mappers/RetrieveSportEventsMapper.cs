using OddsApiClient.Requests;
using RestSharp;

namespace OddsApiClient.Mappers;

internal static class RetrieveSportEventsMapper
{
  public static RestRequest ToRestRequest(this RetrieveSportEventsRequest request)
    => new RestRequest(OddsClient.SportEventsEndpoint, Method.Get);
}