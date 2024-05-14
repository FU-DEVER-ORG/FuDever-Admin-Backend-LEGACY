using System;
using System.Threading;
using System.Threading.Tasks;

namespace FuDever.Domain.Repositories.Hobby.UpdateHobbyByHobbyId;

/// <summary>
///     Query for updating hobby by hobby id feature.
/// </summary>
public interface IUpdateHobbyByHobbyIdQuery
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
    ///     Is hobby found by hobby id.
    /// </summary>
    /// <param name="hobbyId">
    ///     Hobby id.
    /// </param>
    /// <param name="cancellationToken">
    ///     A token that is used to notify the system
    ///     to cancel the current operation when user stop
    ///     the request.
    /// </param>
    /// <returns>
    ///     True if hobby is found by hobby
    ///     id. Otherwise, false.
    /// </returns>
    Task<bool> IsHobbyFoundByHobbyIdQueryAsync(Guid hobbyId, CancellationToken cancellationToken);

    /// <summary>
    ///     Is hobby temporarily removed by hobby id.
    /// </summary>
    /// <param name="hobbyId">
    ///     Hobby id.
    /// </param>
    /// <param name="cancellationToken">
    ///     A token that is used to notify the system
    ///     to cancel the current operation when user stop
    ///     the request.
    /// </param>
    /// <returns>
    ///     True if hobby is temporarily removed by hobby id.
    ///     Otherwise, false.
    /// </returns>
    Task<bool> IsHobbyTemporarilyRemovedByHobbyIdQueryAsync(
        Guid hobbyId,
        CancellationToken cancellationToken
    );

    /// <summary>
    ///     Get all hobby by hobby id for cache clearing.
    /// </summary>
    /// <param name="cancellationToken">
    ///     A token that is used to notify the system
    ///     to cancel the current operation when user stop.
    /// </param>
    /// <param name="hobbyId">
    ///     Hobby id.
    /// </param>
    /// <returns>
    ///     Hobby with hobby name for cache clearing.
    /// </returns>
    Task<Entities.Hobby> FindHobbyByHobbyIdForCacheClearing(
        Guid hobbyId,
        CancellationToken cancellationToken
    );

    /// <summary>
    ///     Is hobby with the same name found by hobby name query.
    /// </summary>
    /// <param name="newHobbyName">
    ///     New hobby name.
    /// </param>
    /// <param name="cancellationToken">
    ///     Token to cancel the operation.
    /// </param>
    /// <returns>
    ///     True if hobby with the same name found. Otherwise, false.
    /// </returns>
    Task<bool> IsHobbyWithTheSameNameFoundByHobbyNameQueryAsync(
        string newHobbyName,
        CancellationToken cancellationToken
    );
}
