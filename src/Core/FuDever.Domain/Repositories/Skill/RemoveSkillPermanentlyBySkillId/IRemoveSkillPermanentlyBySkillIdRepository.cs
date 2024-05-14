namespace FuDever.Domain.Repositories.Skill.RemoveSkillPermanentlyBySkillId;

public interface IRemoveSkillPermanentlyBySkillIdRepository
{
    IRemoveSkillPermanentlyBySkillIdCommand Command { get; }

    IRemoveSkillPermanentlyBySkillIdQuery Query { get; }
}
