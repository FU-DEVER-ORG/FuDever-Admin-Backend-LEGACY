using FuDever.Domain.Repositories.Skill.UpdateSkillBySkillId;
using FuDever.PostgresSql.Data;

namespace FuDever.PostgresSql.Repositories.Skill.UpdateSkillBySkillId.Others;

internal sealed class UpdateSkillBySkillIdRepository : IUpdateSkillBySkillIdRepository
{
    private readonly UpdateSkillBySkillIdStateBag _stateBag;
    private IUpdateSkillBySkillIdCommand _commnad;
    private IUpdateSkillBySkillIdQuery _query;

    internal UpdateSkillBySkillIdRepository(FuDeverContext context)
    {
        _stateBag = new(context: context);
    }

    public IUpdateSkillBySkillIdCommand Command
    {
        get { return _commnad ??= new UpdateSkillBySkillIdCommand(stateBag: _stateBag); }
    }

    public IUpdateSkillBySkillIdQuery Query
    {
        get { return _query ??= new UpdateSkillBySkillIdQuery(stateBag: _stateBag); }
    }
}
