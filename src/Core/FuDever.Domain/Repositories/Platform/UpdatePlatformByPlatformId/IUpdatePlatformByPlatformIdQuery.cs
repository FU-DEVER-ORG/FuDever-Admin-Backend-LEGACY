﻿using System;
using System.Threading;
using System.Threading.Tasks;

namespace FuDever.Domain.Repositories.Platform.UpdatePlatformByPlatformId;

public interface IUpdatePlatformByPlatformIdQuery
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
    ///     Is platform found by platform id.
    /// </summary>
    /// <param name="platformId">
    ///     Platform id.
    /// </param>
    /// <param name="cancellationToken">
    ///     A token that is used to notify the system
    ///     to cancel the current operation when user stop
    ///     the request.
    /// </param>
    /// <returns>
    ///     True if platform is found by platform
    ///     id. Otherwise, false.
    /// </returns>
    Task<bool> IsPlatformFoundByPlatformIdQueryAsync(
        Guid platformId,
        CancellationToken cancellationToken
    );

    /// <summary>
    ///     Is platform temporarily removed by platform id.
    /// </summary>
    /// <param name="platformId">
    ///     Platform id.
    /// </param>
    /// <param name="cancellationToken">
    ///     A token that is used to notify the system
    ///     to cancel the current operation when user stop
    ///     the request.
    /// </param>
    /// <returns>
    ///     True if platform is temporarily removed by platform id.
    ///     Otherwise, false.
    /// </returns>
    Task<bool> IsPlatformTemporarilyRemovedByPlatformIdQueryAsync(
        Guid platformId,
        CancellationToken cancellationToken
    );

    /// <summary>
    ///     Get all platform by platform id for cache clearing.
    /// </summary>
    /// <param name="cancellationToken">
    ///     A token that is used to notify the system
    ///     to cancel the current operation when user stop.
    /// </param>
    /// <param name="platformId">
    ///     Platform id.
    /// </param>
    /// <returns>
    ///     Platform with platform name for cache clearing.
    /// </returns>
    Task<Entities.Platform> FindPlatformByPlatformIdForCacheClearing(
        Guid platformId,
        CancellationToken cancellationToken
    );

    /// <summary>
    ///     Is platform with the same name found by platform name query.
    /// </summary>
    /// <param name="newPlatformName">
    ///     New platform name.
    /// </param>
    /// <param name="cancellationToken">
    ///     Token to cancel the operation.
    /// </param>
    /// <returns>
    ///     True if platform with the same name found. Otherwise, false.
    /// </returns>
    Task<bool> IsPlatformWithTheSameNameFoundByPlatformNameQueryAsync(
        string newPlatformName,
        CancellationToken cancellationToken
    );
}
