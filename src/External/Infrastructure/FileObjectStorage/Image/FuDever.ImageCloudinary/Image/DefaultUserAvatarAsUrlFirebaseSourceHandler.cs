using FuDever.Application.Shared.FIleObjectStorage;

namespace FuDever.ImageCloudinary.Image;

/// <summary>
///     Implementation of default avatar url handler.
/// </summary>
internal sealed class DefaultUserAvatarAsUrlFirebaseSourceHandler : IDefaultUserAvatarAsUrlHandler
{
    private const string DefaultUserAvatarUrl =
        "https://res.cloudinary.com/dy1uuo6ql/image/upload/v1712152128/FU_DEVER_ADMIN/default/nk9md2oaolkix39hqbzm.png";

    public string Get()
    {
        return DefaultUserAvatarUrl;
    }
}
