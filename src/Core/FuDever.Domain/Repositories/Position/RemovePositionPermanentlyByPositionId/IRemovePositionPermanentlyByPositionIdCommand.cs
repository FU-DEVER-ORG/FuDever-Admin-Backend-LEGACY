using System;
using System.Threading;
using System.Threading.Tasks;

namespace FuDever.Domain.Repositories.Position.RemovePositionPermanentlyByPositionId;

public interface IRemovePositionPermanentlyByPositionIdCommand
{
    /// <summary>
    ///     Attempt to remove permanently position by position id.
    /// </summary>
    /// <param name="positionId">
    ///     Position id of permanently removed position.
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
    Task<bool> RemovePositionPermanentlyByPositionIdCommandAsync(
        Guid positionId,
        CancellationToken cancellationToken
    );
}
