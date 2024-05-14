using FuDever.Application.Shared.FIleObjectStorage;
using FuDever.ImageCloudinary.Image;
using Microsoft.Extensions.DependencyInjection;

namespace FuDever.ImageCloudinary;

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
    public static void AddCloudinaryImageStorage(this IServiceCollection services)
    {
        services.AddSingleton<
            IDefaultUserAvatarAsUrlHandler,
            DefaultUserAvatarAsUrlFirebaseSourceHandler
        >();
    }
}
