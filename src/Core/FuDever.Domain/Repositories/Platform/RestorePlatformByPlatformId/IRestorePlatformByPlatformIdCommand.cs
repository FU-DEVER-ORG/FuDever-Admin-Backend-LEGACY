using System;
using System.Threading;
using System.Threading.Tasks;

namespace FuDever.Domain.Repositories.Platform.RestorePlatformByPlatformId;

public interface IRestorePlatformByPlatformIdCommand
{
    /// <summary>
    ///     Attempt to restore platform by platform id.
    /// </summary>
    /// <param name="platformId">
    ///     Platform id of restoring platform.
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
    Task<bool> RestorePlatformByPlatformIdCommandAsync(
        Guid platformId,
        CancellationToken cancellationToken
    );
}
