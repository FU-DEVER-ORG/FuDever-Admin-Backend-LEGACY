using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace FuDever.Domain.Repositories.Platform.GetAllPlatforms;

public interface IGetAllPlatformsQuery
{
    /// <summary>
    ///     Get all non temporarily removed platforms.
    /// </summary>
    /// <param name="cancellationToken">
    ///     The cancellation token.
    /// </param>
    /// <returns>
    ///     List of all non temporarily removed platforms.
    /// </returns>
    Task<IEnumerable<Entities.Platform>> GetAllNonTemporarilyRemovedPlatformsQueryAsync(
        CancellationToken cancellationToken
    );
}
