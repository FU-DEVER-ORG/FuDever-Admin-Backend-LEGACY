using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace FuDever.Domain.Repositories.Department.GetAllDepartments;

/// <summary>
///     Query operations interface for get all departments feature.
/// </summary>
public interface IGetAllDepartmentsQuery
{
    /// <summary>
    ///     Get all departments which are not temporarily removed.
    /// </summary>
    /// <param name="cancellationToken">
    ///     A token that is used for notifying system
    ///     to cancel the current operation when user stop
    ///     the request.
    /// </param>
    /// <returns>
    ///     List of found departments.
    /// </returns>
    Task<IEnumerable<Entities.Department>> GetAllNonTemporarilyRemovedDepartmentsQueryAsync(
        CancellationToken cancellationToken
    );
}
