namespace FuDever.Domain.Repositories.Skill.GetAllSkills;

public interface IGetAllSkillsRepository
{
    IGetAllSkillsCommand Command { get; }

    IGetAllSkillsQuery Query { get; }
}
