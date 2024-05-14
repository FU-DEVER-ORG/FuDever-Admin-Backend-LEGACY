using System.Threading;
using System.Threading.Tasks;

namespace FuDever.Domain.Repositories.Platform.CreatePlatform;

public interface ICreatePlatformCommand
{
    /// <summary>
    ///     Command operations interface for creating a platform feature.
    /// </summary>
    /// <param name="newPlatform">
    ///     The new platform.
    /// </param>
    /// <param name="cancellationToken">
    ///     The cancellation token for the task.
    /// </param>
    /// <returns>
    ///     A boolean value indicating whether the operation was successful or not.
    /// </returns>
    Task<bool> CreatePlatformCommandAsync(
        Entities.Platform newPlatform,
        CancellationToken cancellationToken
    );
}
