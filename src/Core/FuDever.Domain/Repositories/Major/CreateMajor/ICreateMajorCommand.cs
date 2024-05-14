using System.Threading;
using System.Threading.Tasks;

namespace FuDever.Domain.Repositories.Major.CreateMajor;

public interface ICreateMajorCommand
{
    /// <summary>
    ///     Command operations interface for creating a major feature.
    /// </summary>
    /// <param name="newMajor">
    ///     The new major.
    /// </param>
    /// <param name="cancellationToken">
    ///     The cancellation token for the task.
    /// </param>
    /// <returns>
    ///     A boolean value indicating whether the operation was successful or not.
    /// </returns>
    Task<bool> CreateMajorCommandAsync(
        Entities.Major newMajor,
        CancellationToken cancellationToken
    );
}
