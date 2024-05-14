using System.Threading;
using System.Threading.Tasks;

namespace FuDever.Domain.Repositories.Department.CreateDepartment;

/// <summary>
///     Command operations interface for creating a department feature.
/// </summary>
public interface ICreateDepartmentCommand
{
    /// <summary>
    ///     Attempt to creating a new department with the
    ///     given name and add to database.
    /// </summary>
    /// <param name="newDepartment">
    ///     New department.
    /// </param>
    /// <param name="cancellationToken">
    ///     A token that is used to notify the system
    ///     to cancel the current operation when user stop
    ///     the request.
    /// </param>
    /// <returns>
    ///     True if adding department operation is successful.
    ///     Otherwise, false.
    /// </returns>
    Task<bool> CreateDepartmentCommandAsync(
        Entities.Department newDepartment,
        CancellationToken cancellationToken
    );
}
