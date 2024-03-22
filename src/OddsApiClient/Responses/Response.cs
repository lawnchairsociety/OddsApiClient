namespace OddsApiClient.Responses;
public abstract class Response
{
    /// <summary>
    /// Number of requests used
    /// </summary>
    public int RequestsUsed { get; set; }

    /// <summary>
    /// Number of requests remaining
    /// </summary>
    public int RequestsRemaining { get; set; }
}
