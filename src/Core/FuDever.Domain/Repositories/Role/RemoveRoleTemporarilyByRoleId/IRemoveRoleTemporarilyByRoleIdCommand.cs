using System;
using System.Threading;
using System.Threading.Tasks;

namespace FuDever.Domain.Repositories.Role.RemoveRoleTemporarilyByRoleId;

public interface IRemoveRoleTemporarilyByRoleIdCommand
{
    /// <summary>
    ///     Attempt to remove this role temporarily.
    /// </summary>
    /// <param name="roleId">
    ///     Role id of temporarily removed role.
    /// </param>
    /// <param name="removedBy">
    ///     User who removed this role temporarily.
    ///     It's used for audit purpose.
    ///     It should be a valid user id.
    /// </param>
    /// <param name="removedAt">
    ///     Date and time when this role was removed
    /// </param>
    /// <param name="cancellationToken">
    ///     A token that is used to notify the system
    ///     to cancel the current operation when user stop
    ///     the request.
    /// </param>
    /// <returns>
    ///     True if removed successfully. Otherwise, false.
    /// </returns>
    Task<bool> RemoveRoleTemporarilyByRoleIdCommandAsync(
        Guid roleId,
        Guid removedBy,
        DateTime removedAt,
        CancellationToken cancellationToken
    );
}
