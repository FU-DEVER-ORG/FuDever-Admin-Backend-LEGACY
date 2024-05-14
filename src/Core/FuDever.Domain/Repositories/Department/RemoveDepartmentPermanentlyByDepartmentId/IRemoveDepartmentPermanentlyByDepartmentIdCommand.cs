using System;
using System.Threading;
using System.Threading.Tasks;

namespace FuDever.Domain.Repositories.Department.RemoveDepartmentPermanentlyByDepartmentId;

/// <summary>
///     Command interface for remove department
///     permanently by department id feature.
/// </summary>
public interface IRemoveDepartmentPermanentlyByDepartmentIdCommand
{
    /// <summary>
    ///     Attempt to remove permanently department by department id.
    /// </summary>
    /// <param name="departmentId">
    ///     Department id of permanently removed department.
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
    Task<bool> RemoveDepartmentPermanentlyByDepartmentIdCommandAsync(
        Guid departmentId,
        CancellationToken cancellationToken
    );
}
