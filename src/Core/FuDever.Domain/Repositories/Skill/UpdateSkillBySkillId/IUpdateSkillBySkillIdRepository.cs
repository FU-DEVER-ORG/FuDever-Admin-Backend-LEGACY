namespace FuDever.Domain.Repositories.Skill.UpdateSkillBySkillId;

public interface IUpdateSkillBySkillIdRepository
{
    IUpdateSkillBySkillIdCommand Command { get; }

    IUpdateSkillBySkillIdQuery Query { get; }
}
