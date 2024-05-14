using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace FuDever.Domain.Repositories.Skill.GetAllSkills;

public interface IGetAllSkillsQuery
{
    /// <summary>
    ///     Get all non temporarily removed skills.
    /// </summary>
    /// <param name="cancellationToken">
    ///     The cancellation token.
    /// </param>
    /// <returns>
    ///     List of all non temporarily removed skills.
    /// </returns>
    Task<IEnumerable<Entities.Skill>> GetAllNonTemporarilyRemovedSkillsQueryAsync(
        CancellationToken cancellationToken
    );
}
