using System;
using System.Threading;
using System.Threading.Tasks;

namespace FuDever.Domain.Repositories.Hobby.RestoreHobbyByHobbyId;

/// <summary>
///     Command for restpre hobby by hobby id feature.
/// </summary>
public interface IRestoreHobbyByHobbyIdCommand
{
    /// <summary>
    ///     Attempt to restore hobby by hobby id.
    /// </summary>
    /// <param name="hobbyId">
    ///     Hobby id of restoring hobby.
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
    Task<bool> RestoreHobbyByHobbyIdCommandAsync(Guid hobbyId, CancellationToken cancellationToken);
}
