using System;
using System.Threading;
using System.Threading.Tasks;

namespace FuDever.Domain.Repositories.Platform.RemovePlatformTemporarilyByPlatformId;

public interface IRemovePlatformTemporarilyByPlatformIdCommand
{
    /// <summary>
    ///     Attempt to remove this platform temporarily.
    /// </summary>
    /// <param name="platformId">
    ///     Platform id of temporarily removed platform.
    /// </param>
    /// <param name="removedBy">
    ///     User who removed this platform temporarily.
    ///     It's used for audit purpose.
    ///     It should be a valid user id.
    /// </param>
    /// <param name="removedAt">
    ///     Date and time when this platform was removed
    /// </param>
    /// <param name="cancellationToken">
    ///     A token that is used to notify the system
    ///     to cancel the current operation when user stop
    ///     the request.
    /// </param>
    /// <returns>
    ///     True if removed successfully. Otherwise, false.
    /// </returns>
    Task<bool> RemovePlatformTemporarilyByPlatformIdCommandAsync(
        Guid platformId,
        Guid removedBy,
        DateTime removedAt,
        CancellationToken cancellationToken
    );
}
