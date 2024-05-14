namespace FuDever.Domain.Repositories.Skill.RemoveSkillTemporarilyBySkillId;

public interface IRemoveSkillTemporarilyBySkillIdRepository
{
    IRemoveSkillTemporarilyBySkillIdCommand Command { get; }

    IRemoveSkillTemporarilyBySkillIdQuery Query { get; }
}
