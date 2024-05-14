using System;
using System.Threading;
using System.Threading.Tasks;

namespace FuDever.Domain.Repositories.Platform.UpdatePlatformByPlatformId;

public interface IUpdatePlatformByPlatformIdCommand
{
    /// <summary>
    ///     Attempt to update platform with new name by platform id.
    /// </summary>
    /// <param name="platformId">
    ///     Platform id for platform to be updated.
    /// </param>
    /// <param name="newPlatformName">
    ///     New name for platform.
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
    Task<bool> UpdatePlatformByPlatformIdCommandAsync(
        Guid platformId,
        string newPlatformName,
        CancellationToken cancellationToken
    );
}
