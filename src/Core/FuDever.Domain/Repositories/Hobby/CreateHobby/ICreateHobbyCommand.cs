using System.Threading;
using System.Threading.Tasks;

namespace FuDever.Domain.Repositories.Hobby.CreateHobby;

/// <summary>
///     Command operations interface for creating a hobby feature.
/// </summary>
public interface ICreateHobbyCommand
{
    /// <summary>
    ///     Command operations interface for creating a hobby feature.
    /// </summary>
    /// <param name="newHobby">
    ///     The new hobby.
    /// </param>
    /// <param name="cancellationToken">
    ///     The cancellation token for the task.
    /// </param>
    /// <returns>
    ///     A boolean value indicating whether the operation was successful or not.
    /// </returns>
    Task<bool> CreateHobbyCommandAsync(
        Entities.Hobby newHobby,
        CancellationToken cancellationToken
    );
}
