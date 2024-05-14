using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FuDever.Domain.Repositories.Skill.GetAllSkillsBySkillName;
using FuDever.PostgresSql.Commons;
using FuDever.PostgresSql.Repositories.Skill.GetAllSkillsBySkillName.Others;
using Microsoft.EntityFrameworkCore;

namespace FuDever.PostgresSql.Repositories.Skill.GetAllSkillsBySkillName;

internal sealed class GetAllSkillsBySkillNameQuery : IGetAllSkillsBySkillNameQuery
{
    private readonly GetAllSkillsBySkillNameStateBag _stateBag;

    internal GetAllSkillsBySkillNameQuery(GetAllSkillsBySkillNameStateBag stateBag)
    {
        _stateBag = stateBag;
    }

    public async Task<IEnumerable<Domain.Entities.Skill>> GetAllSkillsBySkillNameQueryAsync(
        string skillName,
        CancellationToken cancellationToken
    )
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
                && EF.Functions.Collate(skill.Name, CommonConstant.DbCollation.CASE_INSENSITIVE)
                    .Equals(skillName)
            )
            .Select(selector: skill => new Domain.Entities.Skill
            {
                Id = skill.Id,
                Name = skill.Name
            })
            .ToListAsync(cancellationToken: cancellationToken);
    }
}
