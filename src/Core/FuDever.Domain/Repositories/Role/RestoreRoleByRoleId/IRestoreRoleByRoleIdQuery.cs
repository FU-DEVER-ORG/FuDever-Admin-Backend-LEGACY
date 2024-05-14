using System;
using System.Threading;
using System.Threading.Tasks;

namespace FuDever.Domain.Repositories.Role.RestoreRoleByRoleId;

public interface IRestoreRoleByRoleIdQuery
{
    /// <summary>
    ///     Finds a refresh token by the access token id.
    /// </summary>
    /// <param name="accessTokenId">
    ///     The id of the access token.
    /// </param>
    /// <param name="cancellationToken">
    ///     The cancellation token.
    /// </param>
    /// <returns>
    ///     True if refresh token is found, otherwise false.
    /// </returns>
    Task<bool> IsRefreshTokenFoundByAccessTokenIdQueryAsync(
        Guid accessTokenId,
        CancellationToken cancellationToken
    );

    /// <summary>
    ///     Is user not temporarily removed query.
    /// </summary>
    /// <param name="userId">
    ///     User id.
    /// </param>
    /// <param name="cancellationToken">
    ///     Token to cancel the operation.
    /// </param>
    /// <returns>
    ///     True if user is not temporarily removed. Otherwise, false.
    /// </returns>
    Task<bool> IsUserNotTemporarilyRemovedQueryAsync(
        Guid userId,
        CancellationToken cancellationToken
    );

    /// <summary>
    ///     Is role found by role id.
    /// </summary>
    /// <param name="roleId">
    ///     Role id.
    /// </param>
    /// <param name="cancellationToken">
    ///     A token that is used to notify the system
    ///     to cancel the current operation when user stop
    ///     the request.
    /// </param>
    /// <returns>
    ///     True if role is found by role
    ///     id. Otherwise, false.
    /// </returns>
    Task<bool> IsRoleFoundByRoleIdQueryAsync(Guid roleId, CancellationToken cancellationToken);

    /// <summary>
    ///     Is role temporarily removed by role id.
    /// </summary>
    /// <param name="roleId">
    ///     Role id.
    /// </param>
    /// <param name="cancellationToken">
    ///     A token that is used to notify the system
    ///     to cancel the current operation when user stop
    ///     the request.
    /// </param>
    /// <returns>
    ///     True if role is temporarily removed by role id.
    ///     Otherwise, false.
    /// </returns>
    Task<bool> IsRoleTemporarilyRemovedByRoleIdQueryAsync(
        Guid roleId,
        CancellationToken cancellationToken
    );

    /// <summary>
    ///     Get all role by role id for cache clearing.
    /// </summary>
    /// <param name="cancellationToken">
    ///     A token that is used to notify the system
    ///     to cancel the current operation when user stop.
    /// </param>
    /// <param name="roleId">
    ///     Role id.
    /// </param>
    /// <returns>
    ///     Role with role name for cache clearing.
    /// </returns>
    Task<Entities.Role> FindRoleByRoleIdForCacheClearing(
        Guid roleId,
        CancellationToken cancellationToken
    );
}
