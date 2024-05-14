using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace FuDever.Domain.Repositories.Platform.GetAllPlatformsByPlatformName;

public interface IGetAllPlatformsByPlatformNameQuery
{
    /// <summary>
    ///     Query for get all platforms by platform name feature.
    /// </summary>
    /// <param name="platformName">
    ///     Name of the platform.
    /// </param>
    /// <param name="cancellationToken">
    ///     Cancellation token for canceling the operation.
    /// </param>
    /// <returns>
    ///     All platforms by platform name.
    /// </returns>
    Task<IEnumerable<Entities.Platform>> GetAllPlatformsByPlatformNameQueryAsync(
        string platformName,
        CancellationToken cancellationToken
    );
}
