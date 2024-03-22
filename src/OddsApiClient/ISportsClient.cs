using OddsApiClient.Exceptions;
using OddsApiClient.Extensions;
using OddsApiClient.Mappers;
using OddsApiClient.Models;
using OddsApiClient.Requests;
using OddsApiClient.Responses;
using RestSharp;

namespace OddsApiClient;

public interface ISportsClient
{
    /// <summary>
    /// Retrieves all available sports and tournaments.
    /// </summary>
    /// <param name="request">The request.</param>
    /// <param name="cancellation">The token used to cancel the operation.</param>
    /// <returns>The response.</returns>
    /// <exception cref="OddsApiClientUnauthorizedException"></exception>
    /// <exception cref="OddsApiClientInvalidParameterException"></exception>
    /// <exception cref="OddsApiClientTooManyRequestsException"></exception>
    /// <exception cref="OddsApiClientInternalErrorException"></exception>
    Task<RetrieveSportsResponse> RetrieveSportsAsync(RetrieveSportsRequest request, CancellationToken cancellation = default);
}

public class SportsClient
  : ISportsClient
{
    internal const string SportsEndpoint = "/v4/sports";

    private readonly IRestClient _client;

    public SportsClient(IRestClient client)
    {
        this._client = client;
    }

    /// <inheritdoc/>
    public async Task<RetrieveSportsResponse> RetrieveSportsAsync(RetrieveSportsRequest request, CancellationToken cancellation = default)
    {
        cancellation.ThrowIfCancellationRequested();

        var restRequest = request.ToRestRequest();
        var response = await this._client.ExecuteAsync<List<Sport>>(restRequest, cancellation);
        if (response.IsSuccessful)
        {
            _ = int.TryParse(this._client.GetHeaderValue(response, "x-requests-used"), out int used);
            _ = int.TryParse(this._client.GetHeaderValue(response, "x-requests-remaining"), out int remaining);
            return new RetrieveSportsResponse
            {
                RequestsUsed = used,
                RequestsRemaining = remaining,
                Sports = response.Data!
            };
        }

        throw this._client.BuildExceptionFromResponse(response);
    }
}
