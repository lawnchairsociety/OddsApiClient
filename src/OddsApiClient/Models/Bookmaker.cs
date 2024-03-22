using System.Text.Json.Serialization;

namespace OddsApiClient.Models;

public class Bookmaker
{
    /// <summary>
    /// A unique slug (key) of the bookmaker.
    /// </summary>
    public string Key { get; set; } = string.Empty;

    /// <summary>
    /// A formatted title of the bookmaker.
    /// </summary>
    public string Title { get; set; } = string.Empty;

    /// <summary>
    /// A timestamp of when the bookmaker's odds were last read.
    /// </summary>
    [JsonPropertyName("last_update")]
    public DateTime? LastUpdate { get; set; }

    /// <summary>
    /// A list of markets for the given bookmaker.
    /// </summary>
    public List<Market>? Markets { get; set; }
}
