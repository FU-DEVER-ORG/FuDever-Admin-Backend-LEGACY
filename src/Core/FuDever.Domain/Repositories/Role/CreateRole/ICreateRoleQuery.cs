using System;
using System.Threading;
using System.Threading.Tasks;

namespace FuDever.Domain.Repositories.Role.CreateRole;

public interface ICreateRoleQuery
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
    ///     Is role with the same name found by role name query.
    /// </summary>
    /// <param name="newRoleName">
    ///     New role name.
    /// </param>
    /// <param name="cancellationToken">
    ///     Token to cancel the operation.
    /// </param>
    /// <returns>
    ///     True if role with the same name found. Otherwise, false.
    /// </returns>
    Task<bool> IsRoleWithTheSameNameFoundByRoleNameQueryAsync(
        string newRoleName,
        CancellationToken cancellationToken
    );

    /// <summary>
    ///     Is role temporarily removed by role name query.
    /// </summary>
    /// <param name="newRoleName">
    ///     New role name.
    /// </param>
    /// <param name="cancellationToken">
    ///     Token to cancel the operation.
    /// </param>
    /// <returns>
    ///     True if role is temporarily removed. Otherwise, false.
    /// </returns>
    Task<bool> IsRoleTemporarilyRemovedByRoleNameQueryAsync(
        string newRoleName,
        CancellationToken cancellationToken
    );
}
