using System;
using System.Threading;
using System.Threading.Tasks;

namespace FuDever.Domain.Repositories.Position.RemovePositionTemporarilyByPositionId;

public interface IRemovePositionTemporarilyByPositionIdCommand
{
    /// <summary>
    ///     Attempt to remove this position temporarily.
    /// </summary>
    /// <param name="positionId">
    ///     Position id of temporarily removed position.
    /// </param>
    /// <param name="removedBy">
    ///     User who removed this position temporarily.
    ///     It's used for audit purpose.
    ///     It should be a valid user id.
    /// </param>
    /// <param name="removedAt">
    ///     Date and time when this position was removed
    /// </param>
    /// <param name="cancellationToken">
    ///     A token that is used to notify the system
    ///     to cancel the current operation when user stop
    ///     the request.
    /// </param>
    /// <returns>
    ///     True if removed successfully. Otherwise, false.
    /// </returns>
    Task<bool> RemovePositionTemporarilyByPositionIdCommandAsync(
        Guid positionId,
        Guid removedBy,
        DateTime removedAt,
        CancellationToken cancellationToken
    );
}
