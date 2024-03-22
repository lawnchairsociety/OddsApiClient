namespace OddsApiClient;

public class OddsApiClientOptions
{
    public string BaseUrl { get; set; } = string.Empty;
    public string ApiKey { get; set; } = string.Empty;
}

internal static class OddsApiClientOptionsExtensions
{
    public static void Validate(this OddsApiClientOptions options)
    {
        var errors = new List<string>();

        if (string.IsNullOrWhiteSpace(options.BaseUrl))
        {
            errors.Add($"'{nameof(options.BaseUrl)}' cannot be empty.");
        }

        if (string.IsNullOrWhiteSpace(options.ApiKey))
        {
            errors.Add($"'{nameof(options.ApiKey)}' cannot be empty.");
        }

        if (errors.Count == 0) return;

        var combined = string.Join("\n\t * ", errors);
        throw new ArgumentException($"{nameof(OddsApiClientOptions)} Errors:\n\t * {combined}");
    }
}
