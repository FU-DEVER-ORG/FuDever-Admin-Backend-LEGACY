using FuDever.PostgresSql.Data;
using Microsoft.EntityFrameworkCore;

namespace FuDever.PostgresSql.Repositories.Skill.GetAllSkillsBySkillName.Others;

internal sealed class GetAllSkillsBySkillNameStateBag
{
    private DbSet<Domain.Entities.Skill> _skills;

    internal DbSet<Domain.Entities.Skill> Skills
    {
        get { return _skills ??= Context.Set<Domain.Entities.Skill>(); }
    }

    internal FuDeverContext Context { get; }

    internal GetAllSkillsBySkillNameStateBag(FuDeverContext context)
    {
        Context = context;
    }
}
