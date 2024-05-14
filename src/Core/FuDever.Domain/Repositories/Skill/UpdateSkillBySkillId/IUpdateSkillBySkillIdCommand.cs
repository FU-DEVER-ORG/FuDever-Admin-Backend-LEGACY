using System;
using System.Threading;
using System.Threading.Tasks;

namespace FuDever.Domain.Repositories.Skill.UpdateSkillBySkillId;

public interface IUpdateSkillBySkillIdCommand
{
    /// <summary>
    ///     Attempt to update skill with new name by skill id.
    /// </summary>
    /// <param name="skillId">
    ///     Skill id for skill to be updated.
    /// </param>
    /// <param name="newSkillName">
    ///     New name for skill.
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
    Task<bool> UpdateSkillBySkillIdCommandAsync(
        Guid skillId,
        string newSkillName,
        CancellationToken cancellationToken
    );
}
