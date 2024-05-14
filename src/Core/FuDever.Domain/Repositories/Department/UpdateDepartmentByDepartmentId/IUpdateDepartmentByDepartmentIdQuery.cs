using System;
using System.Threading;
using System.Threading.Tasks;

namespace FuDever.Domain.Repositories.Department.UpdateDepartmentByDepartmentId;

/// <summary>
///     Query interface for update
///     department by department id feature.
/// </summary>
public interface IUpdateDepartmentByDepartmentIdQuery
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
    ///     Is department found by department id.
    /// </summary>
    /// <param name="departmentId">
    ///     Department id.
    /// </param>
    /// <param name="cancellationToken">
    ///     A token that is used to notify the system
    ///     to cancel the current operation when user stop
    ///     the request.
    /// </param>
    /// <returns>
    ///     True if department is found by department
    ///     id. Otherwise, false.
    /// </returns>
    Task<bool> IsDepartmentFoundByDepartmentIdQueryAsync(
        Guid departmentId,
        CancellationToken cancellationToken
    );

    /// <summary>
    ///     Is department temporarily removed by department id.
    /// </summary>
    /// <param name="departmentId">
    ///     Department id.
    /// </param>
    /// <param name="cancellationToken">
    ///     A token that is used to notify the system
    ///     to cancel the current operation when user stop
    ///     the request.
    /// </param>
    /// <returns>
    ///     True if department is temporarily removed by department id.
    ///     Otherwise, false.
    /// </returns>
    Task<bool> IsDepartmentTemporarilyRemovedByDepartmentIdQueryAsync(
        Guid departmentId,
        CancellationToken cancellationToken
    );

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
    ///     Get all departments by department id for cache clearing.
    /// </summary>
    /// <param name="cancellationToken">
    ///     A token that is used to notify the system
    ///     to cancel the current operation when user stop.
    /// </param>
    /// <param name="departmentId">
    ///     Department id.
    /// </param>
    /// <returns>
    ///     Department with department name for cache clearing.
    /// </returns>
    Task<Entities.Department> FindDepartmentByDepartmentIdForCacheClearing(
        Guid departmentId,
        CancellationToken cancellationToken
    );
}
