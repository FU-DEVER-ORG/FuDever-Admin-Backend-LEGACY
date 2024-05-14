using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace FuDever.Domain.Repositories.Hobby.GetAllHobbiesByHobbyName;

/// <summary>
///     Query for get all hobbies by hobby name feature.
/// </summary>
public interface IGetAllHobbiesByHobbyNameQuery
{
    /// <summary>
    ///     Query for get all hobbies by hobby name feature.
    /// </summary>
    /// <param name="hobbyName">
    ///     Name of the hobby.
    /// </param>
    /// <param name="cancellationToken">
    ///     Cancellation token for canceling the operation.
    /// </param>
    /// <returns>
    ///     All hobbies by hobby name.
    /// </returns>
    Task<IEnumerable<Entities.Hobby>> GetAllHobbiesByHobbyNameQueryAsync(
        string hobbyName,
        CancellationToken cancellationToken
    );
}
