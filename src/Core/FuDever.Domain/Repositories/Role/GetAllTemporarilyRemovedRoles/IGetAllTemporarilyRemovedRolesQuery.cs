﻿using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace FuDever.Domain.Repositories.Role.GetAllTemporarilyRemovedRoles;

public interface IGetAllTemporarilyRemovedRolesQuery
{
    /// <summary>
    ///     Get all roles which are temporarily removed.
    /// </summary>
    /// <param name="cancellationToken">
    ///     A token that is used for notifying system
    ///     to cancel the current operation when user stop
    ///     the request.
    /// </param>
    /// <returns>
    ///     List of found roles.
    /// </returns>
    Task<IEnumerable<Entities.Role>> GetAllTemporarilyRemovedRolesQueryAsync(
        CancellationToken cancellationToken
    );

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
}
