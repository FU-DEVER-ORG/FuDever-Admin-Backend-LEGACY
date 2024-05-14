using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace FuDever.Domain.Repositories.Position.GetAllPositionsByPositionName;

public interface IGetAllPositionsByPositionNameQuery
{
    /// <summary>
    ///     Query for get all positions by position name feature.
    /// </summary>
    /// <param name="positionName">
    ///     Name of the position.
    /// </param>
    /// <param name="cancellationToken">
    ///     Cancellation token for canceling the operation.
    /// </param>
    /// <returns>
    ///     All positions by position name.
    /// </returns>
    Task<IEnumerable<Entities.Position>> GetAllPositionsByPositionNameQueryAsync(
        string positionName,
        CancellationToken cancellationToken
    );
}
