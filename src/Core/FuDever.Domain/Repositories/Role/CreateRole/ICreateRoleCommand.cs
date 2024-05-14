using System.Threading;
using System.Threading.Tasks;

namespace FuDever.Domain.Repositories.Role.CreateRole;

public interface ICreateRoleCommand
{
    /// <summary>
    ///     Command operations interface for creating a role feature.
    /// </summary>
    /// <param name="newRole">
    ///     The new role.
    /// </param>
    /// <param name="cancellationToken">
    ///     The cancellation token for the task.
    /// </param>
    /// <returns>
    ///     A boolean value indicating whether the operation was successful or not.
    /// </returns>
    Task<bool> CreateRoleCommandAsync(Entities.Role newRole, CancellationToken cancellationToken);
}
