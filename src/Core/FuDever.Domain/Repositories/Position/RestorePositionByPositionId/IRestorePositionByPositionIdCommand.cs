using System;
using System.Threading;
using System.Threading.Tasks;

namespace FuDever.Domain.Repositories.Position.RestorePositionByPositionId;

public interface IRestorePositionByPositionIdCommand
{
    /// <summary>
    ///     Attempt to restore position by position id.
    /// </summary>
    /// <param name="positionId">
    ///     Position id of restoring position.
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
    Task<bool> RestorePositionByPositionIdCommandAsync(
        Guid positionId,
        CancellationToken cancellationToken
    );
}
