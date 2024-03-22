using OddsApiClient.Exceptions;
using OddsApiClient.Extensions;
using OddsApiClient.Mappers;
using OddsApiClient.Models;
using OddsApiClient.Requests;
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
    Task<List<Sport>> RetrieveSportsAsync(RetrieveSportsRequest request, CancellationToken cancellation = default);
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
    public async Task<List<Sport>> RetrieveSportsAsync(RetrieveSportsRequest request, CancellationToken cancellation = default)
    {
        cancellation.ThrowIfCancellationRequested();

        var restRequest = request.ToRestRequest();
        var response = await this._client.ExecuteAsync<List<Sport>>(restRequest, cancellation);
        if (response.IsSuccessful) return response.Data!;

        throw this._client.BuildExceptionFromResponse(response);
    }
}
