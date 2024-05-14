using System;
using System.Threading;
using System.Threading.Tasks;

namespace FuDever.Domain.Repositories.Hobby.RemoveHobbyPermanentlyByHobbyId;

/// <summary>
///     Command for remove hobby permanently by hobby id feature.
/// </summary>
public interface IRemoveHobbyPermanentlyByHobbyIdCommand
{
    /// <summary>
    ///     Attempt to remove permanently hobby by hobby id.
    /// </summary>
    /// <param name="hobbyId">
    ///     Hobby id of permanently removed hobby.
    /// </param>
    /// <param name="cancellationToken">
    ///     A token that is used to notify the system
    ///     to cancel the current operation when user stop
    ///     the request.
    /// </param>
    /// <returns>
    ///     True if operation is successful.
    ///     Otherwise, false.
    /// </returns>
    Task<bool> RemoveHobbyPermanentlyByHobbyIdCommandAsync(
        Guid hobbyId,
        CancellationToken cancellationToken
    );
}
