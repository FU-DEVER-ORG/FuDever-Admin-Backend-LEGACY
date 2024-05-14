using FuDever.Domain.Repositories.Skill.RemoveSkillPermanentlyBySkillId;
using FuDever.PostgresSql.Data;

namespace FuDever.PostgresSql.Repositories.Skill.RemoveSkillPermanentlyBySkillId.Others;

internal sealed class RemoveSkillPermanentlyBySkillIdRepository
    : IRemoveSkillPermanentlyBySkillIdRepository
{
    private readonly RemoveSkillPermanentlyBySkillIdStateBag _stateBag;
    private IRemoveSkillPermanentlyBySkillIdCommand _commnad;
    private IRemoveSkillPermanentlyBySkillIdQuery _query;

    internal RemoveSkillPermanentlyBySkillIdRepository(FuDeverContext context)
    {
        _stateBag = new(context: context);
    }

    public IRemoveSkillPermanentlyBySkillIdCommand Command
    {
        get { return _commnad ??= new RemoveSkillPermanentlyBySkillIdCommand(stateBag: _stateBag); }
    }

    public IRemoveSkillPermanentlyBySkillIdQuery Query
    {
        get { return _query ??= new RemoveSkillPermanentlyBySkillIdQuery(stateBag: _stateBag); }
    }
}
