using System;
using System.Threading;
using System.Threading.Tasks;

namespace FuDever.Domain.Repositories.Department.RemoveDepartmentTemporarilyByDepartmentId;

/// <summary>
///     Command interface for remove department
///     temporarily by department id feature.
/// </summary>
public interface IRemoveDepartmentTemporarilyByDepartmentIdCommand
{
    /// <summary>
    ///     Attempt to remove this department temporarily.
    /// </summary>
    /// <param name="departmentId">
    ///     Department id of temporarily removed department.
    /// </param>
    /// <param name="removedBy">
    ///     User who removed this department temporarily.
    ///     It's used for audit purpose.
    ///     It should be a valid user id.
    /// </param>
    /// <param name="removedAt">
    ///     Date and time when this department was removed
    /// </param>
    /// <param name="cancellationToken">
    ///     A token that is used to notify the system
    ///     to cancel the current operation when user stop
    ///     the request.
    /// </param>
    /// <returns>
    ///     True if removed successfully. Otherwise, false.
    /// </returns>
    Task<bool> RemoveDepartmentTemporarilyByDepartmentIdCommandAsync(
        Guid departmentId,
        Guid removedBy,
        DateTime removedAt,
        CancellationToken cancellationToken
    );
}
