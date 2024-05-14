using System;
using System.Threading;
using System.Threading.Tasks;

namespace FuDever.Domain.Repositories.Skill.RemoveSkillTemporarilyBySkillId;

public interface IRemoveSkillTemporarilyBySkillIdCommand
{
    /// <summary>
    ///     Attempt to remove this skill temporarily.
    /// </summary>
    /// <param name="skillId">
    ///     Skill id of temporarily removed skill.
    /// </param>
    /// <param name="removedBy">
    ///     User who removed this skill temporarily.
    ///     It's used for audit purpose.
    ///     It should be a valid user id.
    /// </param>
    /// <param name="removedAt">
    ///     Date and time when this skill was removed
    /// </param>
    /// <param name="cancellationToken">
    ///     A token that is used to notify the system
    ///     to cancel the current operation when user stop
    ///     the request.
    /// </param>
    /// <returns>
    ///     True if removed successfully. Otherwise, false.
    /// </returns>
    Task<bool> RemoveSkillTemporarilyBySkillIdCommandAsync(
        Guid skillId,
        Guid removedBy,
        DateTime removedAt,
        CancellationToken cancellationToken
    );
}
