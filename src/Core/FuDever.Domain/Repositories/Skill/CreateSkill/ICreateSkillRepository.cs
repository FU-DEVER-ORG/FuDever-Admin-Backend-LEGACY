namespace FuDever.Domain.Repositories.Skill.CreateSkill;

public interface ICreateSkillRepository
{
    ICreateSkillCommand Command { get; }

    ICreateSkillQuery Query { get; }
}
