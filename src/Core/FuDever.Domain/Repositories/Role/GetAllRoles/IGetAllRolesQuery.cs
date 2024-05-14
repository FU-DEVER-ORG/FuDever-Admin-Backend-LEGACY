using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace FuDever.Domain.Repositories.Role.GetAllRoles;

public interface IGetAllRolesQuery
{
    /// <summary>
    ///     Get all non temporarily removed roles.
    /// </summary>
    /// <param name="cancellationToken">
    ///     The cancellation token.
    /// </param>
    /// <returns>
    ///     List of all non temporarily removed roles.
    /// </returns>
    Task<IEnumerable<Entities.Role>> GetAllNonTemporarilyRemovedRolesQueryAsync(
        CancellationToken cancellationToken
    );
}
