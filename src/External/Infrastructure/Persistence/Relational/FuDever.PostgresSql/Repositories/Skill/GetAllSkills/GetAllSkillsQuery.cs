using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FuDever.Domain.Repositories.Skill.GetAllSkills;
using FuDever.PostgresSql.Commons;
using FuDever.PostgresSql.Repositories.Skill.GetAllSkills.Others;
using Microsoft.EntityFrameworkCore;

namespace FuDever.PostgresSql.Repositories.Skill.GetAllSkills;

internal sealed class GetAllSkillsQuery : IGetAllSkillsQuery
{
    private readonly GetAllSkillsStateBag _stateBag;

    internal GetAllSkillsQuery(GetAllSkillsStateBag stateBag)
    {
        _stateBag = stateBag;
    }

    public async Task<
        IEnumerable<Domain.Entities.Skill>
    > GetAllNonTemporarilyRemovedSkillsQueryAsync(CancellationToken cancellationToken)
    {
        // Linq-base
        return await _stateBag
            .Skills.AsNoTracking()
            .Where(predicate: skill =>
                skill.RemovedAt == CommonConstant.DbDefaultValue.MIN_DATE_TIME
                && skill.RemovedBy
                    == Application.Shared.Commons.CommonConstant.App.DEFAULT_ENTITY_ID_AS_GUID
                && skill.Id
                    != Application.Shared.Commons.CommonConstant.App.DEFAULT_ENTITY_ID_AS_GUID
            )
            .Select(selector: skill => new Domain.Entities.Skill
            {
                Id = skill.Id,
                Name = skill.Name
            })
            .ToListAsync(cancellationToken: cancellationToken);
    }
}
