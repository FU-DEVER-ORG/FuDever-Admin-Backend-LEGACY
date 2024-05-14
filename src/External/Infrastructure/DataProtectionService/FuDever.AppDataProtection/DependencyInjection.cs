using FuDever.AppDataProtection.Handler;
using FuDever.Application.DataProtection;
using FuDever.Configuration.Presentation.WebApi.DataProtection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FuDever.AppDataProtection;

/// <summary>
///     Configure services for this layer.
/// </summary>
public static class DependencyInjection
{
    /// <summary>
    ///     Entry to configuring multiple services.
    /// </summary>
    /// <param name="services">
    ///     Service container.
    /// </param>
    /// <param name="configuration">
    ///     Load configuration for configuration
    ///     file (appsetting).
    /// </param>
    public static void AddAppDataProtection(
        this IServiceCollection services,
        IConfigurationManager configuration
    )
    {
        services.AddDataProtection();

        services
            .AddSingleton<IDataProtectionHandler, AppDataProtectionHandler>()
            .AddSingleton(
                implementationInstance: configuration
                    .GetRequiredSection(key: "DataProtection")
                    .Get<DataProtectionOption>()
            );
    }
}
