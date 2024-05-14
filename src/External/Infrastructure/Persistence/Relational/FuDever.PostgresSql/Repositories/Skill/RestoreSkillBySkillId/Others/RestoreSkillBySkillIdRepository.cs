using FuDever.Domain.Repositories.Skill.RestoreSkillBySkillId;
using FuDever.PostgresSql.Data;

namespace FuDever.PostgresSql.Repositories.Skill.RestoreSkillBySkillId.Others;

internal sealed class RestoreSkillBySkillIdRepository : IRestoreSkillBySkillIdRepository
{
    private readonly RestoreSkillBySkillIdStateBag _stateBag;
    private IRestoreSkillBySkillIdCommand _commnad;
    private IRestoreSkillBySkillIdQuery _query;

    internal RestoreSkillBySkillIdRepository(FuDeverContext context)
    {
        _stateBag = new(context: context);
    }

    public IRestoreSkillBySkillIdCommand Command
    {
        get { return _commnad ??= new RestoreSkillBySkillIdCommand(stateBag: _stateBag); }
    }

    public IRestoreSkillBySkillIdQuery Query
    {
        get { return _query ??= new RestoreSkillBySkillIdQuery(stateBag: _stateBag); }
    }
}
