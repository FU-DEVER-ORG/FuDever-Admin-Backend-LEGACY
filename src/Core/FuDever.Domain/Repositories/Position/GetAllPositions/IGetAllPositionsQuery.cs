using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace FuDever.Domain.Repositories.Position.GetAllPositions;

public interface IGetAllPositionsQuery
{
    /// <summary>
    ///     Get all non temporarily removed positions.
    /// </summary>
    /// <param name="cancellationToken">
    ///     The cancellation token.
    /// </param>
    /// <returns>
    ///     List of all non temporarily removed positions.
    /// </returns>
    Task<IEnumerable<Entities.Position>> GetAllNonTemporarilyRemovedPositionsQueryAsync(
        CancellationToken cancellationToken
    );
}
