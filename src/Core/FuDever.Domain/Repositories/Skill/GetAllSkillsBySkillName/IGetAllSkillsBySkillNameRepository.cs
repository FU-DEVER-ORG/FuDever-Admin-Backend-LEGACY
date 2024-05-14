namespace FuDever.Domain.Repositories.Skill.GetAllSkillsBySkillName;

public interface IGetAllSkillsBySkillNameRepository
{
    IGetAllSkillsBySkillNameCommand Command { get; }

    IGetAllSkillsBySkillNameQuery Query { get; }
}
