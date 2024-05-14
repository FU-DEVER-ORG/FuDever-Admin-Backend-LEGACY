using System;
using System.Threading;
using System.Threading.Tasks;

namespace FuDever.Domain.Repositories.Department.UpdateDepartmentByDepartmentId;

/// <summary>
///     Command interface for update
///     department by department id feature.
/// </summary>
public interface IUpdateDepartmentByDepartmentIdCommand
{
    /// <summary>
    ///     Attempt to update department with new name by department id.
    /// </summary>
    /// <param name="departmentId">
    ///     Department id for department to be updated.
    /// </param>
    /// <param name="newDepartmentName">
    ///     New name for department.
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
    Task<bool> UpdateDepartmentByDepartmentIdCommandAsync(
        Guid departmentId,
        string newDepartmentName,
        CancellationToken cancellationToken
    );
}
