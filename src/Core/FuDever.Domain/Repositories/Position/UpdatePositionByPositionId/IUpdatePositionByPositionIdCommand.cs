using System;
using System.Threading;
using System.Threading.Tasks;

namespace FuDever.Domain.Repositories.Position.UpdatePositionByPositionId;

public interface IUpdatePositionByPositionIdCommand
{
    /// <summary>
    ///     Attempt to update position with new name by position id.
    /// </summary>
    /// <param name="positionId">
    ///     Position id for position to be updated.
    /// </param>
    /// <param name="newPositionName">
    ///     New name for position.
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
    Task<bool> UpdatePositionByPositionIdCommandAsync(
        Guid positionId,
        string newPositionName,
        CancellationToken cancellationToken
    );
}
