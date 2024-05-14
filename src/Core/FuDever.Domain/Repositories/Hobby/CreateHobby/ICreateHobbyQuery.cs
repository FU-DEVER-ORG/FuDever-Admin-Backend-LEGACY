using System;
using System.Threading;
using System.Threading.Tasks;

namespace FuDever.Domain.Repositories.Hobby.CreateHobby;

/// <summary>
///     Query operations interface for creating a hobby feature.
/// </summary>
public interface ICreateHobbyQuery
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

    /// <summary>
    ///     Is hobby temporarily removed by hobby name query.
    /// </summary>
    /// <param name="newHobbyName">
    ///     New hobby name.
    /// </param>
    /// <param name="cancellationToken">
    ///     Token to cancel the operation.
    /// </param>
    /// <returns>
    ///     True if hobby is temporarily removed. Otherwise, false.
    /// </returns>
    Task<bool> IsHobbyTemporarilyRemovedByHobbyNameQueryAsync(
        string newHobbyName,
        CancellationToken cancellationToken
    );
}
