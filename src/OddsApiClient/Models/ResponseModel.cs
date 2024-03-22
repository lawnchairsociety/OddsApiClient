namespace OddsApiClient.Models;
public abstract class ResponseModel
{
    /// <summary>
    /// Number of requests made
    /// </summary>
    public int RequestsUsed { get; set; }

    /// <summary>
    /// Number of requests remaining
    /// </summary>
    public int RequestsRemaining { get; set; }
}
