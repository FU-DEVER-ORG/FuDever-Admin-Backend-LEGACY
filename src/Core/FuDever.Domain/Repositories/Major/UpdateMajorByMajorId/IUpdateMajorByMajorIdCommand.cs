using System;
using System.Threading;
using System.Threading.Tasks;

namespace FuDever.Domain.Repositories.Major.UpdateMajorByMajorId;

public interface IUpdateMajorByMajorIdCommand
{
    /// <summary>
    ///     Attempt to update major with new name by major id.
    /// </summary>
    /// <param name="majorId">
    ///     Major id for major to be updated.
    /// </param>
    /// <param name="newMajorName">
    ///     New name for major.
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
    Task<bool> UpdateMajorByMajorIdCommandAsync(
        Guid majorId,
        string newMajorName,
        CancellationToken cancellationToken
    );
}
