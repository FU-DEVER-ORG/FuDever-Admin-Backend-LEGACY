using System;
using System.Threading;
using System.Threading.Tasks;

namespace FuDever.Domain.Repositories.Department.CreateDepartment;

/// <summary>
///     Query operations interface for creating a department feature.
/// </summary>
public interface ICreateDepartmentQuery
{
    /// <summary>
    ///     Is department having the same name with
    ///     the new one found.
    /// </summary>
    /// <param name="newDepartmentName">
    ///     New department name.
    /// </param>
    /// <param name="cancellationToken">
    ///     A token that is used to notify the system
    ///     to cancel the current operation when user stop
    ///     the request.
    /// </param>
    /// <returns>
    ///     True if department already exists. Otherwise, false.
    /// </returns>
    Task<bool> IsDepartmentWithTheSameNameFoundByDepartmentNameQueryAsync(
        string newDepartmentName,
        CancellationToken cancellationToken
    );

    /// <summary>
    ///     Is department temporarily removed by department name.
    /// </summary>
    /// <param name="newDepartmentName">
    ///     New department name.
    /// </param>
    /// <param name="cancellationToken">
    ///     A token that is used to notify the system
    ///     to cancel the current operation when user stop
    ///     the request.
    /// </param>
    /// <returns>
    ///     True if department already temporarily removed. Otherwise, false.
    /// </returns>
    Task<bool> IsDepartmentTemporarilyRemovedByDepartmentNameQueryAsync(
        string newDepartmentName,
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
