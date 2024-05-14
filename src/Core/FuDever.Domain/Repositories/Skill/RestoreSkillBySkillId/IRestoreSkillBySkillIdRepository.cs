namespace FuDever.Domain.Repositories.Skill.RestoreSkillBySkillId;

public interface IRestoreSkillBySkillIdRepository
{
    IRestoreSkillBySkillIdCommand Command { get; }

    IRestoreSkillBySkillIdQuery Query { get; }
}
