using System.Threading;
using System.Threading.Tasks;

namespace FuDever.Domain.Repositories.Position.CreatePosition;

public interface ICreatePositionCommand
{
    /// <summary>
    ///     Command operations interface for creating a position feature.
    /// </summary>
    /// <param name="newPosition">
    ///     The new position.
    /// </param>
    /// <param name="cancellationToken">
    ///     The cancellation token for the task.
    /// </param>
    /// <returns>
    ///     A boolean value indicating whether the operation was successful or not.
    /// </returns>
    Task<bool> CreatePositionCommandAsync(
        Entities.Position newPosition,
        CancellationToken cancellationToken
    );
}
