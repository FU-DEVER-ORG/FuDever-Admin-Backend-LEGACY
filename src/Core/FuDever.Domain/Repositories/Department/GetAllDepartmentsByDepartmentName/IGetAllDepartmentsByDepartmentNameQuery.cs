using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace FuDever.Domain.Repositories.Department.GetAllDepartmentsByDepartmentName;

/// <summary>
///     Query operations interface for get all
///     departments by department name feature.
/// </summary>
public interface IGetAllDepartmentsByDepartmentNameQuery
{
    /// <summary>
    ///     Retrieves all departments based on
    ///     the department name asynchronously.
    /// </summary>
    /// <param name="departmentName">
    ///     The name of the department to search for.
    /// </param>
    /// <param name="cancellationToken">
    ///     The cancellation token.
    /// </param>
    /// <returns>
    ///     A task representing the asynchronous operation
    ///     that yields an enumerable collection of departments.
    /// </returns>
    Task<IEnumerable<Entities.Department>> GetAllDepartmentsByDepartmentNameQueryAsync(
        string departmentName,
        CancellationToken cancellationToken
    );
}
