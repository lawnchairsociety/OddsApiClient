using System.Text.Json.Serialization;

namespace OddsApiClient.Models;

public class HistoricalSportOdds
{
    /// <summary>
    /// The timestamp of the snapshot.
    /// </summary>
    public DateTime? Timestamp { get; set; }

    /// <summary>
    /// The preceding available timestamp.
    /// </summary>
    [JsonPropertyName("previous_timestamp")]
    public DateTime? PreviousTimestamp { get; set; }

    /// <summary>
    /// The next available timestamp.
    /// </summary>
    [JsonPropertyName("next_timestamp")]
    public DateTime? NextTimestamp { get; set; }

    /// <summary>
    /// A list of live and upcoming events at the time of the snapshot.
    /// </summary>
    public List<Odds>? Data { get; set; }
}
