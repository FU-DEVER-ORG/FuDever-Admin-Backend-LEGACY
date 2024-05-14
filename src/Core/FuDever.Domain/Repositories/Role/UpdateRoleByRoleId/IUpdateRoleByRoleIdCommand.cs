using System;
using System.Threading;
using System.Threading.Tasks;

namespace FuDever.Domain.Repositories.Role.UpdateRoleByRoleId;

public interface IUpdateRoleByRoleIdCommand
{
    /// <summary>
    ///     Attempt to update role with new name by role id.
    /// </summary>
    /// <param name="roleId">
    ///     Role id for role to be updated.
    /// </param>
    /// <param name="newRoleName">
    ///     New name for role.
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
    Task<bool> UpdateRoleByRoleIdCommandAsync(
        Guid roleId,
        string newRoleName,
        CancellationToken cancellationToken
    );
}
