using System;
using System.Threading;
using System.Threading.Tasks;

namespace FuDever.Domain.Repositories.Department.RestoreDepartmentByDepartmentId;

/// <summary>
///     Command interface for restore
///     department by department id feature.
/// </summary>
public interface IRestoreDepartmentByDepartmentIdCommand
{
    /// <summary>
    ///     Attempt to restore department by department id.
    /// </summary>
    /// <param name="departmentId">
    ///     Department id of restoring department.
    /// </param>
    /// <param name="cancellationToken">
    ///     A token that is used to notify the system
    ///     to cancel the current operation when user stop
    ///     the request.
    /// </param>
    /// <returns>
    ///     True if operation is successful.
    ///     Otherwise, false.
    /// </returns>
    Task<bool> RestoreDepartmentByDepartmentIdCommandAsync(
        Guid departmentId,
        CancellationToken cancellationToken
    );
}
