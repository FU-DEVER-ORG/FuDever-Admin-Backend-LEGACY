using FuDever.Domain.Repositories.Skill.CreateSkill;
using FuDever.PostgresSql.Data;

namespace FuDever.PostgresSql.Repositories.Skill.CreateSkill.Others;

internal sealed class CreateSkillRepository : ICreateSkillRepository
{
    private readonly CreateSkillStateBag _stateBag;
    private ICreateSkillQuery _query;
    private ICreateSkillCommand _command;

    internal CreateSkillRepository(FuDeverContext context)
    {
        _stateBag = new(context: context);
    }

    public ICreateSkillQuery Query
    {
        get { return _query ??= new CreateSkillQuery(stateBag: _stateBag); }
    }

    public ICreateSkillCommand Command
    {
        get { return _command ??= new CreateSkillCommand(stateBag: _stateBag); }
    }
}
