using System.Globalization;
using OddsApiClient.Requests;
using Xunit;

namespace OddsApiClient.Tests.Client;

public class EventsClientTests
{

    [Fact]
    public async Task RetrieveSportEventsAsync_WhenGivenValidRequest_ItShouldRetrieveEvents()
    {
        // Arrange
        var responseFile = Path.Combine("Events", "RetrieveSportEventsAsyncResponse.json");
        var responseJson = ResponseLoader.Load(responseFile);
        var handler = new JsonResponseHttpMessageHandler(responseJson);
        var restClient = TestHelpers.GetRestClient(handler);
        var request = new RetrieveSportEventsRequest
        {
            Sport = "icehockey_nhl",
            DateFormat = "iso",
        };

        // Act
        var client = new EventsClient(restClient);
        var response = await client.RetrieveSportEventsAsync(request);

        // Assert
        Assert.NotNull(response);
        Assert.True(response.Count > 0);
        Assert.Equal("b33f30ad5541b19794da293edee78bd3", response[0].Id);
        Assert.Equal("icehockey_nhl", response[0].SportKey);
        Assert.Equal("NHL", response[0].SportTitle);
        Assert.Equal(DateTime.Parse("2024-03-21T23:00:00Z", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind), response[0].CommenceTime);
        Assert.Equal("Boston Bruins", response[0].HomeTeam);
        Assert.Equal("New York Rangers", response[0].AwayTeam);

        Assert.NotNull(handler.Request?.RequestUri);
        Assert.Contains($"/v4/sports/{request.Sport}/events", handler.Request.RequestUri.AbsoluteUri);
    }

    [Fact]
    public async Task RetrieveSportEventOddsAsync_WhenGivenValidRequest_ItShouldRetrieveEventOdds()
    {
        // Arrange
        var responseFile = Path.Combine("Events", "RetrieveSportEventOddsAsyncResponse.json");
        var responseJson = ResponseLoader.Load(responseFile);
        var handler = new JsonResponseHttpMessageHandler(responseJson);
        var restClient = TestHelpers.GetRestClient(handler);
        var request = new RetrieveSportEventOddsRequest
        {
            Sport = "icehockey_nhl",
            EventId = "b33f30ad5541b19794da293edee78bd3",
            Regions = "us",
            Markets = "h2h",
            DateFormat = "iso",
            OddsFormat = "decimal"
        };

        // Act
        var client = new EventsClient(restClient);
        var response = await client.RetrieveSportEventOddsAsync(request);

        // Assert
        Assert.NotNull(response);
        Assert.Equal("b33f30ad5541b19794da293edee78bd3", response.Id);
        Assert.Equal("icehockey_nhl", response.SportKey);
        Assert.Equal("NHL", response.SportTitle);
        Assert.Equal(DateTime.Parse("2024-03-21T23:00:00Z", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind), response.CommenceTime);
        Assert.Equal("Boston Bruins", response.HomeTeam);
        Assert.Equal("New York Rangers", response.AwayTeam);
        Assert.Equal("unibet_us", response.Bookmakers![0].Key);
        Assert.Equal("Unibet", response.Bookmakers![0].Title);
        Assert.Equal("h2h", response.Bookmakers![0].Markets![0].Key);
        Assert.Equal(DateTime.Parse("2024-03-21T14:10:14Z", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind), response.Bookmakers![0].Markets![0].LastUpdate);
        Assert.Equal("Boston Bruins", response.Bookmakers![0].Markets![0].Outcomes![0].Name);
        Assert.Equal(1.7, response.Bookmakers![0].Markets![0].Outcomes![0].Price);
        Assert.Equal("New York Rangers", response.Bookmakers![0].Markets![0].Outcomes![1].Name);
        Assert.Equal(2.2, response.Bookmakers![0].Markets![0].Outcomes![1].Price);

        Assert.NotNull(handler.Request?.RequestUri);
        Assert.Contains($"/v4/sports/{request.Sport}/events/{request.EventId}/odds", handler.Request.RequestUri.AbsoluteUri);
    }

    [Fact]
    public async Task RetrieveSportScoresAsync_WhenGivenValidRequest_ItShouldRetrieveScores()
    {
        // Arrange
        var responseFile = Path.Combine("Events", "RetrieveSportScoresAsyncResponse.json");
        var responseJson = ResponseLoader.Load(responseFile);
        var handler = new JsonResponseHttpMessageHandler(responseJson);
        var restClient = TestHelpers.GetRestClient(handler);
        var request = new RetrieveSportScoresRequest
        {
            Sport = "icehockey_nhl",
            DaysFrom = 3,
            DateFormat = "iso",
        };

        // Act
        var client = new EventsClient(restClient);
        var response = await client.RetrieveSportScoresAsync(request);

        // Assert
        Assert.NotNull(response);
        Assert.True(response.Count > 0);
        Assert.Equal("2aeab0a9d68f90299e8f38870d1d816c", response[0].Id);
        Assert.Equal("icehockey_nhl", response[0].SportKey);
        Assert.Equal("Calgary Flames", response[0].HomeTeam);
        Assert.Equal("Washington Capitals", response[0].AwayTeam);
        Assert.Equal("Calgary Flames", response[0].Scores![0].Name);
        Assert.Equal("Washington Capitals", response[0].Scores![1].Name);
        Assert.Equal("2", response[0].Scores![0].Score);
        Assert.Equal("5", response[0].Scores![1].Score);

        Assert.NotNull(handler.Request?.RequestUri);
        Assert.Contains($"/v4/sports/{request.Sport}/scores", handler.Request.RequestUri.AbsoluteUri);
    }

    [Fact]
    public async Task RetrieveSportOddsAsync_WhenGivenValidRequest_ItShouldRetrieveSportOdds()
    {
        // Arrange
        var responseFile = Path.Combine("Events", "RetrieveSportOddsAsyncResponse.json");
        var responseJson = ResponseLoader.Load(responseFile);
        var handler = new JsonResponseHttpMessageHandler(responseJson);
        var restClient = TestHelpers.GetRestClient(handler);
        var request = new RetrieveSportOddsRequest
        {
            Sport = "icehockey_nhl",
            Regions = "us",
            Markets = "h2h",
            DateFormat = "iso",
            OddsFormat = "decimal"
        };

        // Act
        var client = new EventsClient(restClient);
        var response = await client.RetrieveSportOddsAsync(request);

        // Assert
        Assert.NotNull(response);
        Assert.True(response.Count > 0);
        Assert.Equal("b33f30ad5541b19794da293edee78bd3", response[0].Id);
        Assert.Equal("icehockey_nhl", response[0].SportKey);
        Assert.Equal("NHL", response[0].SportTitle);
        Assert.Equal("Boston Bruins", response[0].HomeTeam);
        Assert.Equal("New York Rangers", response[0].AwayTeam);
        Assert.Equal("unibet_us", response[0].Bookmakers![0].Key);
        Assert.Equal("Unibet", response[0].Bookmakers![0].Title);
        Assert.Equal(DateTime.Parse("2024-03-21T14:10:14Z", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind), response[0].Bookmakers![0].LastUpdate);
        Assert.Equal("h2h", response[0].Bookmakers![0].Markets![0].Key);
        Assert.Equal(DateTime.Parse("2024-03-21T14:10:14Z", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind), response[0].Bookmakers![0].Markets![0].LastUpdate);
        Assert.Equal("Boston Bruins", response[0].Bookmakers![0].Markets![0].Outcomes![0].Name);
        Assert.Equal(1.7, response[0].Bookmakers![0].Markets![0].Outcomes![0].Price);
        Assert.Equal("New York Rangers", response[0].Bookmakers![0].Markets![0].Outcomes![1].Name);
        Assert.Equal(2.2, response[0].Bookmakers![0].Markets![0].Outcomes![1].Price);

        Assert.NotNull(handler.Request?.RequestUri);
        Assert.Contains($"/v4/sports/{request.Sport}/odds", handler.Request.RequestUri.AbsoluteUri);
    }
}
