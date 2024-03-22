using Xunit;
using OddsApiClient.Requests;
using System.Globalization;

namespace OddsApiClient.Tests.Client;

public class HistoricalClientTests
{
    [Fact]
    public async Task RetrieveHistoricalSportOddsAsync_WhenGivenValidRequest_ItShouldRetrieveHistoricalSportsEvents()
    {
        // Arrange
        var responseFile = Path.Combine("Historical", "RetrieveHistoricalSportOddsAsyncResponse.json");
        var responseJson = ResponseLoader.Load(responseFile);
        var handler = new JsonResponseHttpMessageHandler(responseJson);
        var restClient = TestHelpers.GetRestClient(handler);
        var request = new RetrieveHistoricalSportOddsRequest
        {
            Sport = "americanfootball_nfl",
            Date = DateTime.Parse("2021-11-25T12:00:00Z"),
            Regions = "us",
            OddsFormat = "american",
            DateFormat = "iso",
            Markets = "h2h,spreads,totals"
        };

        // Act
        var client = new HistoricalClient(restClient);
        var response = await client.RetrieveHistoricalSportOddsAsync(request);

        // Assert
        Assert.NotNull(response);
        Assert.Equal(DateTime.Parse("2021-11-25T11:55:00Z", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind), response.Timestamp);
        Assert.Equal(DateTime.Parse("2021-11-25T11:45:00Z", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind), response.PreviousTimestamp);
        Assert.Equal(DateTime.Parse("2021-11-25T12:05:00Z", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind), response.NextTimestamp);
        Assert.Equal("b6b7f177d3f5cee88b630f09c287453c", response.Data![0].Id);
        Assert.Equal("americanfootball_nfl", response.Data![0].SportKey);
        Assert.Equal("NFL", response.Data![0].SportTitle);
        Assert.Equal(DateTime.Parse("2021-11-25T17:30:00Z", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind), response.Data![0].CommenceTime);
        Assert.Equal("Detroit Lions", response.Data![0].HomeTeam);
        Assert.Equal("Chicago Bears", response.Data![0].AwayTeam);
        Assert.Equal("betonlineag", response.Data![0].Bookmakers![0].Key);
        Assert.Equal("BetOnline.ag", response.Data![0].Bookmakers![0].Title);
        Assert.Equal(DateTime.Parse("2021-11-25T11:49:47Z", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind), response.Data![0].Bookmakers![0].LastUpdate);
        Assert.Equal("spreads", response.Data![0].Bookmakers![0].Markets![0].Key);
        Assert.Equal("Chicago Bears", response.Data![0].Bookmakers![0].Markets![0].Outcomes![0].Name);
        Assert.Equal(104, response.Data![0].Bookmakers![0].Markets![0].Outcomes![0].Price);
        Assert.Equal(-3.0, response.Data![0].Bookmakers![0].Markets![0].Outcomes![0].Point);
        Assert.Equal("Detroit Lions", response.Data![0].Bookmakers![0].Markets![0].Outcomes![1].Name);
        Assert.Equal(-125, response.Data![0].Bookmakers![0].Markets![0].Outcomes![1].Price);
        Assert.Equal(3.0, response.Data![0].Bookmakers![0].Markets![0].Outcomes![1].Point);
        Assert.Equal("totals", response.Data![0].Bookmakers![0].Markets![1].Key);
        Assert.Equal("Over", response.Data![0].Bookmakers![0].Markets![1].Outcomes![0].Name);
        Assert.Equal(-119, response.Data![0].Bookmakers![0].Markets![1].Outcomes![0].Price);
        Assert.Equal(41.0, response.Data![0].Bookmakers![0].Markets![1].Outcomes![0].Point);
        Assert.Equal("Under", response.Data![0].Bookmakers![0].Markets![1].Outcomes![1].Name);
        Assert.Equal(-101, response.Data![0].Bookmakers![0].Markets![1].Outcomes![1].Price);
        Assert.Equal(41.0, response.Data![0].Bookmakers![0].Markets![1].Outcomes![1].Point);
        Assert.Equal("h2h", response.Data![0].Bookmakers![0].Markets![2].Key);
        Assert.Equal("Chicago Bears", response.Data![0].Bookmakers![0].Markets![2].Outcomes![0].Name);
        Assert.Equal(-145, response.Data![0].Bookmakers![0].Markets![2].Outcomes![0].Price);
        Assert.Equal("Detroit Lions", response.Data![0].Bookmakers![0].Markets![2].Outcomes![1].Name);
        Assert.Equal(125, response.Data![0].Bookmakers![0].Markets![2].Outcomes![1].Price);

        Assert.NotNull(handler.Request?.RequestUri);
        Assert.Contains($"/v4/historical/sports/{request.Sport}/odds", handler.Request.RequestUri.AbsoluteUri);
    }
}
