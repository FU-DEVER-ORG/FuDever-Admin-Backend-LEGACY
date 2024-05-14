using FuDever.Application.FIleObjectStorage;
using FuDever.Firebase.Image;
using Microsoft.Extensions.DependencyInjection;

namespace FuDever.Firebase;

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
    public static void AddFirebaseImageStorage(this IServiceCollection services)
    {
        services.AddSingleton<
            IDefaultUserAvatarAsUrlHandler,
            DefaultUserAvatarAsUrlFirebaseSourceHandler
        >();
    }
}
