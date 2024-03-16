using NUnit.Framework;
using NUnit.Framework.Legacy;
using OddsApiClient.Requests;

namespace OddsApiClient.Tests.Client;

public class OddsApiClientTests
{
  // Setup
  private IOddsClient _client;
  private readonly string baseUrl = "https://api.the-odds-api.com";
  private readonly string apiKey = "";

  [SetUp]
  public void Before()
  {
    this._client = new OddsClient(this.baseUrl, this.apiKey);
  }

  [Test]
  public async Task Test_RetrieveSportsAsync()
  {
    // Setup
    var request = new RetrieveSportsRequest
    {
      All = true
    };

    // Calls
    var response = await this._client.RetrieveSportsAsync(request);

    // Verify
    ClassicAssert.IsNotNull(response, "Invalid response returned");
    CollectionAssert.AllItemsAreUnique(response);
  }

  [Test]
  public async Task Test_RetrieveSportScoresAsync()
  {
    // Setup
    var request = new RetrieveSportScoresRequest
    {
      Sport = "icehockey_nhl",
      DaysFrom = 3,
      DateFormat = "iso"
    };

    // Calls
    var response = await this._client.RetrieveSportScoresAsync(request);

    // Verify
    ClassicAssert.IsNotNull(response, "Invalid response returned");
    CollectionAssert.AllItemsAreUnique(response);
  }

  [Test]
  public async Task Test_RetrieveSportEventsAsync()
  {
    // Setup
    var request = new RetrieveSportEventsRequest
    {
      Sport = "icehockey_nhl",
      DateFormat = "iso"
    };

    // Calls
    var response = await this._client.RetrieveSportEventsAsync(request);

    // Verify
    ClassicAssert.IsNotNull(response, "Invalid response returned");
    CollectionAssert.AllItemsAreUnique(response);
  }

  [Test]
  public async Task Test_RetrieveSportOddsAsync()
  {
    // Setup
    var request = new RetrieveSportOddsRequest
    {
      Sport = "icehockey_nhl",
      Regions = "us",
      Markets = "h2h",
      DateFormat = "iso",
      OddsFormat = "decimal"
    };

    // Calls
    var response = await this._client.RetrieveSportOddsAsync(request);

    // Verify
    ClassicAssert.IsNotNull(response, "Invalid response returned");
    CollectionAssert.AllItemsAreUnique(response);
  }

  [Test]
  public async Task Test_RetrieveSportEventOddsAsync()
  {
    // Setup
    var request = new RetrieveSportEventOddsRequest
    {
      Sport = "icehockey_nhl",
      EventId = "26aa6cb753327eaa946057c7c61f3b02",
      Regions = "us",
      Markets = "h2h",
      DateFormat = "iso",
      OddsFormat = "decimal"
    };

    // Calls
    var response = await this._client.RetrieveSportEventOddsAsync(request);

    // Verify
    ClassicAssert.IsNotNull(response, "Invalid response returned");
    CollectionAssert.AllItemsAreUnique(response);
  }

  [Test]
  public async Task Test_RetrieveHistoricalSportEventsAsync()
  {
    // Setup
    var request = new RetrieveHistoricalSportEventsRequest
    {
      Sport = "icehockey_nhl",
      DateFormat = "iso",
      Date = DateTime.UtcNow
    };

    // Calls
    var response = await this._client.RetrieveHistoricalSportEventsAsync(request);

    // Verify
    ClassicAssert.IsNotNull(response, "Invalid response returned");
    CollectionAssert.AllItemsAreUnique(response);
  }

  [Test]
  public async Task Test_RetrieveHistoricalSportOddsAsync()
  {
    // Setup
    var request = new RetrieveHistoricalSportOddsRequest
    {
      Sport = "icehockey_nhl",
      Regions = "us",
      Markets = "h2h",
      DateFormat = "iso",
      OddsFormat = "decimal",
      Date = DateTime.UtcNow
    };

    // Calls
    var response = await this._client.RetrieveHistoricalSportOddsAsync(request);

    // Verify
    ClassicAssert.IsNotNull(response, "Invalid response returned");
    CollectionAssert.AllItemsAreUnique(response);
  }

  [Test]
  public async Task Test_RetrieveHistoricalSportEventOddsAsync()
  {
    // Setup
    var request = new RetrieveHistoricalSportEventOddsRequest
    {
      Sport = "icehockey_nhl",
      EventId = "26aa6cb753327eaa946057c7c61f3b02",
      Regions = "us",
      Markets = "h2h",
      DateFormat = "iso",
      OddsFormat = "decimal",
      Date = DateTime.UtcNow
    };

    // Calls
    var response = await this._client.RetrieveHistoricalSportEventOddsAsync(request);

    // Verify
    ClassicAssert.IsNotNull(response, "Invalid response returned");
  }
}