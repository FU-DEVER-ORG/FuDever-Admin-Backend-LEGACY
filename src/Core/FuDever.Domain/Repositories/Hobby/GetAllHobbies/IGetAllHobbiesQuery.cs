using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace FuDever.Domain.Repositories.Hobby.GetAllHobbies;

/// <summary>
///     Query for all hobbies feature.
/// </summary>
public interface IGetAllHobbiesQuery
{
    /// <summary>
    ///     Get all non temporarily removed hobbies.
    /// </summary>
    /// <param name="cancellationToken">
    ///     The cancellation token.
    /// </param>
    /// <returns>
    ///     List of all non temporarily removed hobbies.
    /// </returns>
    Task<IEnumerable<Entities.Hobby>> GetAllNonTemporarilyRemovedHobbiesQueryAsync(
        CancellationToken cancellationToken
    );
}
