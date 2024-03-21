using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace PapNet;

public static class PapExtensions
{

    public static IServiceCollection AddPapService(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<PapSettings>(configuration.GetSection(nameof(PapSettings)));
        services.AddHttpClient("PapService", httpClient =>
        {
            httpClient.BaseAddress = new Uri(configuration[$"{nameof(PapSettings)}:{nameof(PapSettings.Url)}"]!);
            httpClient.Timeout = TimeSpan.FromSeconds(3);
        });
        services.AddHttpClient("PapTracking", httpClient =>
        {
            httpClient.BaseAddress = new Uri(configuration[$"{nameof(PapSettings)}:{nameof(PapSettings.TrackingUrl)}"]!);
            httpClient.Timeout = TimeSpan.FromSeconds(3);
        });

        services.AddTransient<IPapService, PapService>();
        return services;
    }
}
