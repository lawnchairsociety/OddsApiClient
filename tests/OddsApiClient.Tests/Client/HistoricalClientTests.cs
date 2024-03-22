using System.Globalization;
using OddsApiClient.Requests;
using Xunit;

namespace OddsApiClient.Tests.Client;

public class HistoricalClientTests
{
    [Fact]
    public async Task RetrieveHistoricalSportOddsAsync_WhenGivenValidRequest_ItShouldRetrieveHistoricalSportOdds()
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

    [Fact]
    public async Task RetrieveHistoricalSportEventsAsync_WhenGivenValidRequest_ItShouldRetrieveHistoricalSportEvents()
    {
        // Arrange
        var responseFile = Path.Combine("Historical", "RetrieveHistoricalSportEventsAsyncResponse.json");
        var responseJson = ResponseLoader.Load(responseFile);
        var handler = new JsonResponseHttpMessageHandler(responseJson);
        var restClient = TestHelpers.GetRestClient(handler);
        var request = new RetrieveHistoricalSportEventsRequest
        {
            Sport = "americanfootball_nfl",
            DateFormat = "iso",
            Date = DateTime.Parse("2023-10-10T12:10:39Z")
        };

        // Act
        var client = new HistoricalClient(restClient);
        var response = await client.RetrieveHistoricalSportEventsAsync(request);

        // Assert
        Assert.NotNull(response);
        Assert.Equal(DateTime.Parse("2023-10-10T12:10:39Z", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind), response.Timestamp);
        Assert.Equal(DateTime.Parse("2023-10-10T12:05:39Z", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind), response.PreviousTimestamp);
        Assert.Equal(DateTime.Parse("2023-10-10T12:15:39Z", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind), response.NextTimestamp);
        Assert.Equal("e912304de2b2ce35b473ce2ecd3d1502", response.Data![0].Id);
        Assert.Equal("americanfootball_nfl", response.Data![0].SportKey);
        Assert.Equal("NFL", response.Data![0].SportTitle);
        Assert.Equal(DateTime.Parse("2023-10-11T23:10:00Z", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind), response.Data![0].CommenceTime);
        Assert.Equal("Houston Texans", response.Data![0].HomeTeam);
        Assert.Equal("Kansas City Chiefs", response.Data![0].AwayTeam);

        Assert.NotNull(handler.Request?.RequestUri);
        Assert.Contains($"/v4/historical/sports/{request.Sport}/events", handler.Request.RequestUri.AbsoluteUri);
    }

    [Fact]
    public async Task RetrieveHistoricalSportEventOddsAsync_WhenGivenValidRequest_ItShouldRetrieveHistoricalSportEventOdds()
    {
        // Arrange
        var responseFile = Path.Combine("Historical", "RetrieveHistoricalSportEventOddsAsyncResponse.json");
        var responseJson = ResponseLoader.Load(responseFile);
        var handler = new JsonResponseHttpMessageHandler(responseJson);
        var restClient = TestHelpers.GetRestClient(handler);
        var request = new RetrieveHistoricalSportEventOddsRequest
        {
            Sport = "americanfootball_nfl",
            EventId = "e912304de2b2ce35b473ce2ecd3d1502",
            Regions = "us",
            Markets = "alternate_spreads",
            DateFormat = "iso",
            OddsFormat = "decimal",
            Date = DateTime.Parse("2023-10-10T12:10:39Z")
        };

        // Act
        var client = new HistoricalClient(restClient);
        var response = await client.RetrieveHistoricalSportEventOddsAsync(request);

        // Assert
        Assert.NotNull(response);
        Assert.Equal(DateTime.Parse("2023-10-10T12:10:39Z", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind), response.Timestamp);
        Assert.Equal(DateTime.Parse("2023-10-10T12:05:39Z", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind), response.PreviousTimestamp);
        Assert.Equal(DateTime.Parse("2023-10-10T12:15:39Z", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind), response.NextTimestamp);
        Assert.Equal("e912304de2b2ce35b473ce2ecd3d1502", response.Data.Id);
        Assert.Equal("americanfootball_nfl", response.Data.SportKey);
        Assert.Equal("NFL", response.Data.SportTitle);
        Assert.Equal(DateTime.Parse("2023-10-11T23:10:00Z", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind), response.Data.CommenceTime);
        Assert.Equal("Houston Texans", response.Data.HomeTeam);
        Assert.Equal("Kansas City Chiefs", response.Data.AwayTeam);
        Assert.Equal("draftkings", response.Data.Bookmakers![0].Key);
        Assert.Equal("DraftKings", response.Data.Bookmakers![0].Title);
        Assert.Equal("alternate_spreads", response.Data.Bookmakers![0].Markets![0].Key);
        Assert.Equal(DateTime.Parse("2023-10-10T12:10:29Z", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind), response.Data.Bookmakers![0].Markets![0].LastUpdate);
        Assert.Equal("Houston Texans", response.Data.Bookmakers![0].Markets![0].Outcomes![0].Name);
        Assert.Equal(5.08, response.Data.Bookmakers![0].Markets![0].Outcomes![0].Price);
        Assert.Equal(-23, response.Data.Bookmakers![0].Markets![0].Outcomes![0].Point);

        Assert.NotNull(handler.Request?.RequestUri);
        Assert.Contains($"/v4/historical/sports/{request.Sport}/events/{request.EventId}/odds", handler.Request.RequestUri.AbsoluteUri);
    }
}
