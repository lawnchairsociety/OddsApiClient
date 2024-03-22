namespace OddsApiClient.Models;

public class ScoreModel
{
    /// <summary>
    /// The participant name.
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// The most recent score for the participant.
    /// </summary>
    public string Score { get; set; } = string.Empty;
}
