using FuDever.AppBackgroundJob.Handler;
using Microsoft.Extensions.DependencyInjection;

namespace FuDever.AppBackgroundJob;

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
    public static void AddAppBackgroundJob(this IServiceCollection services)
    {
        services.AddHostedService<KeepAppAliveBackgroundJob>();
    }
}
