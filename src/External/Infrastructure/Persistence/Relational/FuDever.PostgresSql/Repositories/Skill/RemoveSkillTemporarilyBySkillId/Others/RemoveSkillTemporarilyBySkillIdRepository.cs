using FuDever.Domain.Repositories.Skill.RemoveSkillTemporarilyBySkillId;
using FuDever.PostgresSql.Data;

namespace FuDever.PostgresSql.Repositories.Skill.RemoveSkillTemporarilyBySkillId.Others;

internal sealed class RemoveSkillTemporarilyBySkillIdRepository
    : IRemoveSkillTemporarilyBySkillIdRepository
{
    private readonly RemoveSkillTemporarilyBySkillIdStateBag _stateBag;
    private IRemoveSkillTemporarilyBySkillIdCommand _commnad;
    private IRemoveSkillTemporarilyBySkillIdQuery _query;

    internal RemoveSkillTemporarilyBySkillIdRepository(FuDeverContext context)
    {
        _stateBag = new(context: context);
    }

    public IRemoveSkillTemporarilyBySkillIdCommand Command
    {
        get { return _commnad ??= new RemoveSkillTemporarilyBySkillIdCommand(stateBag: _stateBag); }
    }

    public IRemoveSkillTemporarilyBySkillIdQuery Query
    {
        get { return _query ??= new RemoveSkillTemporarilyBySkillIdQuery(stateBag: _stateBag); }
    }
}
