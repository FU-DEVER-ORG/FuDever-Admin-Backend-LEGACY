using FuDever.PostgresSql.Data;
using Microsoft.EntityFrameworkCore;

namespace FuDever.PostgresSql.Repositories.Skill.GetAllSkills.Others;

internal sealed class GetAllSkillsStateBag
{
    private DbSet<Domain.Entities.Skill> _skills;

    internal DbSet<Domain.Entities.Skill> Skills
    {
        get { return _skills ??= Context.Set<Domain.Entities.Skill>(); }
    }

    internal FuDeverContext Context { get; }

    internal GetAllSkillsStateBag(FuDeverContext context)
    {
        Context = context;
    }
}
