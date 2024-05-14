using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace FuDever.Domain.Repositories.Major.GetAllMajorsByMajorName;

public interface IGetAllMajorsByMajorNameQuery
{
    /// <summary>
    ///     Query for get all majors by major name feature.
    /// </summary>
    /// <param name="majorName">
    ///     Name of the major.
    /// </param>
    /// <param name="cancellationToken">
    ///     Cancellation token for canceling the operation.
    /// </param>
    /// <returns>
    ///     All majors by major name.
    /// </returns>
    Task<IEnumerable<Entities.Major>> GetAllMajorsByMajorNameQueryAsync(
        string majorName,
        CancellationToken cancellationToken
    );
}
