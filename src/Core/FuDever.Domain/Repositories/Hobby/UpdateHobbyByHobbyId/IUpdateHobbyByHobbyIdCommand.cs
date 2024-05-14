using System;
using System.Threading;
using System.Threading.Tasks;

namespace FuDever.Domain.Repositories.Hobby.UpdateHobbyByHobbyId;

/// <summary>
///     Command for updating hobby by hobby id feature.
/// </summary>
public interface IUpdateHobbyByHobbyIdCommand
{
    /// <summary>
    ///     Attempt to update hobby with new name by hobby id.
    /// </summary>
    /// <param name="hobbyId">
    ///     Hobby id for hobby to be updated.
    /// </param>
    /// <param name="newHobbyName">
    ///     New name for hobby.
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
    Task<bool> UpdateHobbyByHobbyIdCommandAsync(
        Guid hobbyId,
        string newHobbyName,
        CancellationToken cancellationToken
    );
}
