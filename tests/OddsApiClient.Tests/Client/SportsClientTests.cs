using OddsApiClient.Requests;
using Xunit;

namespace OddsApiClient.Tests.Client;

public class SportsClientTests
{
    [Fact]
    public async Task RetrieveSportsAsync_WhenGivenValidRequest_ItShouldRetrieveSports()
    {
        // Arrange
        var responseFile = Path.Combine("Sports", "RetrieveSportsAsyncResponse.json");
        var responseJson = ResponseLoader.Load(responseFile);
        var handler = new JsonResponseHttpMessageHandler(responseJson);
        var restClient = TestHelpers.GetRestClient(handler);
        var request = new RetrieveSportsRequest
        {
            All = true
        };

        // Act
        var client = new SportsClient(restClient);
        var response = await client.RetrieveSportsAsync(request);

        // Assert
        Assert.NotNull(response);
        Assert.True(response.Count > 0);
        Assert.Equal("americanfootball_cfl", response[0].Key);

        Assert.NotNull(handler.Request?.RequestUri);
        Assert.Contains($"/v4/sports", handler.Request.RequestUri.AbsoluteUri);
    }
}
