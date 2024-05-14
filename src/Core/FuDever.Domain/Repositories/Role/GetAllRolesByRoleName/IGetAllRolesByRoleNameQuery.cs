using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace FuDever.Domain.Repositories.Role.GetAllRolesByRoleName;

public interface IGetAllRolesByRoleNameQuery
{
    /// <summary>
    ///     Query for get all roles by role name feature.
    /// </summary>
    /// <param name="roleName">
    ///     Name of the role.
    /// </param>
    /// <param name="cancellationToken">
    ///     Cancellation token for canceling the operation.
    /// </param>
    /// <returns>
    ///     All roles by role name.
    /// </returns>
    Task<IEnumerable<Entities.Role>> GetAllRolesByRoleNameQueryAsync(
        string roleName,
        CancellationToken cancellationToken
    );
}
