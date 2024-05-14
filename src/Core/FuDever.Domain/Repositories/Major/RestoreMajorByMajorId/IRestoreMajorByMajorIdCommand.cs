using System;
using System.Threading;
using System.Threading.Tasks;

namespace FuDever.Domain.Repositories.Major.RestoreMajorByMajorId;

public interface IRestoreMajorByMajorIdCommand
{
    /// <summary>
    ///     Attempt to restore major by major id.
    /// </summary>
    /// <param name="majorId">
    ///     Major id of restoring major.
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
    Task<bool> RestoreMajorByMajorIdCommandAsync(Guid majorId, CancellationToken cancellationToken);
}
