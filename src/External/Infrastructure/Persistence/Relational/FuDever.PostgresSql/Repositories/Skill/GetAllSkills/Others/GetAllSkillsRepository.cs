using FuDever.Domain.Repositories.Skill.GetAllSkills;
using FuDever.PostgresSql.Data;

namespace FuDever.PostgresSql.Repositories.Skill.GetAllSkills.Others;

internal sealed class GetAllSkillsRepository : IGetAllSkillsRepository
{
    private readonly GetAllSkillsStateBag _stateBag;
    private IGetAllSkillsQuery _query;
    private IGetAllSkillsCommand _command;

    internal GetAllSkillsRepository(FuDeverContext context)
    {
        _stateBag = new(context: context);
    }

    public IGetAllSkillsQuery Query
    {
        get { return _query ??= new GetAllSkillsQuery(stateBag: _stateBag); }
    }

    public IGetAllSkillsCommand Command
    {
        get { return _command ??= new GetAllSkillsCommand(); }
    }
}
