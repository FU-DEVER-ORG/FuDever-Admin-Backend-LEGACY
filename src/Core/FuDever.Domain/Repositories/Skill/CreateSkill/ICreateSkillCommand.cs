using System.Threading;
using System.Threading.Tasks;

namespace FuDever.Domain.Repositories.Skill.CreateSkill;

public interface ICreateSkillCommand
{
    /// <summary>
    ///     Command operations interface for creating a skill feature.
    /// </summary>
    /// <param name="newSkill">
    ///     The new skill.
    /// </param>
    /// <param name="cancellationToken">
    ///     The cancellation token for the task.
    /// </param>
    /// <returns>
    ///     A boolean value indicating whether the operation was successful or not.
    /// </returns>
    Task<bool> CreateSkillCommandAsync(
        Entities.Skill newSkill,
        CancellationToken cancellationToken
    );
}
