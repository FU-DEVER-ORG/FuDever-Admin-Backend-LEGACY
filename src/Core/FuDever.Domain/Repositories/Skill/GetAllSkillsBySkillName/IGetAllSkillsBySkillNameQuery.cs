using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace FuDever.Domain.Repositories.Skill.GetAllSkillsBySkillName;

public interface IGetAllSkillsBySkillNameQuery
{
    /// <summary>
    ///     Query for get all skills by skill name feature.
    /// </summary>
    /// <param name="skillName">
    ///     Name of the skill.
    /// </param>
    /// <param name="cancellationToken">
    ///     Cancellation token for canceling the operation.
    /// </param>
    /// <returns>
    ///     All skills by skill name.
    /// </returns>
    Task<IEnumerable<Entities.Skill>> GetAllSkillsBySkillNameQueryAsync(
        string skillName,
        CancellationToken cancellationToken
    );
}
