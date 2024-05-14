using System;
using System.Threading;
using System.Threading.Tasks;

namespace FuDever.Domain.Repositories.Skill.RemoveSkillPermanentlyBySkillId;

public interface IRemoveSkillPermanentlyBySkillIdCommand
{
    /// <summary>
    ///     Attempt to remove permanently skill by skill id.
    /// </summary>
    /// <param name="skillId">
    ///     Skill id of permanently removed skill.
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
    Task<bool> RemoveSkillPermanentlyBySkillIdCommandAsync(
        Guid skillId,
        CancellationToken cancellationToken
    );
}
