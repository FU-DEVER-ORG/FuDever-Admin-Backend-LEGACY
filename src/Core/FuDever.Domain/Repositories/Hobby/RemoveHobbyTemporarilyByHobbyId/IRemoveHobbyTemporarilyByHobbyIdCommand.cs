using System;
using System.Threading;
using System.Threading.Tasks;

namespace FuDever.Domain.Repositories.Hobby.RemoveHobbyTemporarilyByHobbyId;

/// <summary>
///     Command for remove hobby temporarily by hobby id feature.
/// </summary>
public interface IRemoveHobbyTemporarilyByHobbyIdCommand
{
    /// <summary>
    ///     Attempt to remove this hobby temporarily.
    /// </summary>
    /// <param name="hobbyId">
    ///     Hobby id of temporarily removed hobby.
    /// </param>
    /// <param name="removedBy">
    ///     User who removed this hobby temporarily.
    ///     It's used for audit purpose.
    ///     It should be a valid user id.
    /// </param>
    /// <param name="removedAt">
    ///     Date and time when this hobby was removed
    /// </param>
    /// <param name="cancellationToken">
    ///     A token that is used to notify the system
    ///     to cancel the current operation when user stop
    ///     the request.
    /// </param>
    /// <returns>
    ///     True if removed successfully. Otherwise, false.
    /// </returns>
    Task<bool> RemoveHobbyTemporarilyByHobbyIdCommandAsync(
        Guid hobbyId,
        Guid removedBy,
        DateTime removedAt,
        CancellationToken cancellationToken
    );
}
