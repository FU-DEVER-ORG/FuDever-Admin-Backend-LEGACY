using System;
using System.Threading;
using System.Threading.Tasks;

namespace FuDever.Domain.Repositories.Major.RemoveMajorTemporarilyByMajorId;

public interface IRemoveMajorTemporarilyByMajorIdQuery
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
    ///     Is major found by major id.
    /// </summary>
    /// <param name="majorId">
    ///     Major id.
    /// </param>
    /// <param name="cancellationToken">
    ///     A token that is used to notify the system
    ///     to cancel the current operation when user stop
    ///     the request.
    /// </param>
    /// <returns>
    ///     True if major is found by major
    ///     id. Otherwise, false.
    /// </returns>
    Task<bool> IsMajorFoundByMajorIdQueryAsync(Guid majorId, CancellationToken cancellationToken);

    /// <summary>
    ///     Is major temporarily removed by major id.
    /// </summary>
    /// <param name="majorId">
    ///     Major id.
    /// </param>
    /// <param name="cancellationToken">
    ///     A token that is used to notify the system
    ///     to cancel the current operation when user stop
    ///     the request.
    /// </param>
    /// <returns>
    ///     True if major is temporarily removed by major id.
    ///     Otherwise, false.
    /// </returns>
    Task<bool> IsMajorTemporarilyRemovedByMajorIdQueryAsync(
        Guid majorId,
        CancellationToken cancellationToken
    );

    /// <summary>
    ///     Get all major by major id for cache clearing.
    /// </summary>
    /// <param name="cancellationToken">
    ///     A token that is used to notify the system
    ///     to cancel the current operation when user stop.
    /// </param>
    /// <param name="majorId">
    ///     Major id.
    /// </param>
    /// <returns>
    ///     Major with major name for cache clearing.
    /// </returns>
    Task<Entities.Major> FindMajorByMajorIdForCacheClearing(
        Guid majorId,
        CancellationToken cancellationToken
    );
}
