using System;
using System.Threading;
using System.Threading.Tasks;

namespace FuDever.Domain.Repositories.Role.RemoveRolePermanentlyByRoleId;

public interface IRemoveRolePermanentlyByRoleIdCommand
{
    /// <summary>
    ///     Attempt to remove permanently role by role id.
    /// </summary>
    /// <param name="roleId">
    ///     Role id of permanently removed role.
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
    Task<bool> RemoveRolePermanentlyByRoleIdCommandAsync(
        Guid roleId,
        CancellationToken cancellationToken
    );
}
