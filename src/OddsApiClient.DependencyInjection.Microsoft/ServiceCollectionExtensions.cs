using Microsoft.Extensions.DependencyInjection;

namespace OddsApiClient.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddOddsApiClient(this IServiceCollection services,
        Action<OddsApiClientOptions>? configureOptions = null)
    {
        var options = new OddsApiClientOptions();
        services.AddSingleton(options);
        configureOptions?.Invoke(options);

        services.AddSingleton<IOddsApiClient, OddsApiClient>();

        return services;
    }
}
