using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace FuDever.Domain.Repositories.Major.GetAllMajors;

public interface IGetAllMajorsQuery
{
    /// <summary>
    ///     Get all non temporarily removed majors.
    /// </summary>
    /// <param name="cancellationToken">
    ///     The cancellation token.
    /// </param>
    /// <returns>
    ///     List of all non temporarily removed majors.
    /// </returns>
    Task<IEnumerable<Entities.Major>> GetAllNonTemporarilyRemovedMajorsQueryAsync(
        CancellationToken cancellationToken
    );
}
