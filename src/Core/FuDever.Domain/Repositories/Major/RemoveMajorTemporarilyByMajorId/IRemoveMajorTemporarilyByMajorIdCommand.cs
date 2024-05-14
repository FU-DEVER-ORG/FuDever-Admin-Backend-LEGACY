using System;
using System.Threading;
using System.Threading.Tasks;

namespace FuDever.Domain.Repositories.Major.RemoveMajorTemporarilyByMajorId;

public interface IRemoveMajorTemporarilyByMajorIdCommand
{
    /// <summary>
    ///     Attempt to remove this major temporarily.
    /// </summary>
    /// <param name="majorId">
    ///     Major id of temporarily removed major.
    /// </param>
    /// <param name="removedBy">
    ///     User who removed this major temporarily.
    ///     It's used for audit purpose.
    ///     It should be a valid user id.
    /// </param>
    /// <param name="removedAt">
    ///     Date and time when this major was removed
    /// </param>
    /// <param name="cancellationToken">
    ///     A token that is used to notify the system
    ///     to cancel the current operation when user stop
    ///     the request.
    /// </param>
    /// <returns>
    ///     True if removed successfully. Otherwise, false.
    /// </returns>
    Task<bool> RemoveMajorTemporarilyByMajorIdCommandAsync(
        Guid majorId,
        Guid removedBy,
        DateTime removedAt,
        CancellationToken cancellationToken
    );
}
