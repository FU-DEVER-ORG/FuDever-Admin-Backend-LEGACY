using FuDever.Domain.Repositories.Skill.GetAllTemporarilyRemovedSkills;
using FuDever.PostgresSql.Data;

namespace FuDever.PostgresSql.Repositories.Skill.GetAllTemporarilyRemovedSkills.Others;

internal sealed class GetAllTemporarilyRemovedSkillsRepository
    : IGetAllTemporarilyRemovedSkillsRepository
{
    private readonly GetAllTemporarilyRemovedSkillsStateBag _stateBag;
    private IGetAllTemporarilyRemovedSkillsCommand _commnad;
    private IGetAllTemporarilyRemovedSkillsQuery _query;

    internal GetAllTemporarilyRemovedSkillsRepository(FuDeverContext context)
    {
        _stateBag = new(context: context);
    }

    public IGetAllTemporarilyRemovedSkillsCommand Command
    {
        get { return _commnad ??= new GetAllTemporarilyRemovedSkillsCommand(); }
    }

    public IGetAllTemporarilyRemovedSkillsQuery Query
    {
        get { return _query ??= new GetAllTemporarilyRemovedSkillsQuery(stateBag: _stateBag); }
    }
}
