using System;
using System.Threading;
using System.Threading.Tasks;

namespace FuDever.Domain.Repositories.Platform.RemovePlatformPermanentlyByPlatformId;

public interface IRemovePlatformPermanentlyByPlatformIdCommand
{
    /// <summary>
    ///     Attempt to remove permanently platform by platform id.
    /// </summary>
    /// <param name="platformId">
    ///     Platform id of permanently removed platform.
    /// </param>
    /// <param name="cancellationToken">
    ///     A token that is used to notify the system
    ///     to cancel the current operation when user stop
    ///     the request.
    /// </param>
    /// <returns>
    ///     True if operation is successful.
    ///     Otherwise, false.
    /// </returns>
    Task<bool> RemovePlatformPermanentlyByPlatformIdCommandAsync(
        Guid platformId,
        CancellationToken cancellationToken
    );
}
