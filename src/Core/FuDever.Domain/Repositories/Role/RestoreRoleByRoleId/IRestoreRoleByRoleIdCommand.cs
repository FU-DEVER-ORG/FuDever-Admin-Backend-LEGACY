using System;
using System.Threading;
using System.Threading.Tasks;

namespace FuDever.Domain.Repositories.Role.RestoreRoleByRoleId;

public interface IRestoreRoleByRoleIdCommand
{
    /// <summary>
    ///     Attempt to restore role by role id.
    /// </summary>
    /// <param name="roleId">
    ///     Role id of restoring role.
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
    Task<bool> RestoreRoleByRoleIdCommandAsync(Guid roleId, CancellationToken cancellationToken);
}
