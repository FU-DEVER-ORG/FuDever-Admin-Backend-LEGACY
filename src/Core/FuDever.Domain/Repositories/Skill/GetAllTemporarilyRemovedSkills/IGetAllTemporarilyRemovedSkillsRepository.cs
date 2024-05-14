namespace FuDever.Domain.Repositories.Skill.GetAllTemporarilyRemovedSkills;

public interface IGetAllTemporarilyRemovedSkillsRepository
{
    IGetAllTemporarilyRemovedSkillsCommand Command { get; }

    IGetAllTemporarilyRemovedSkillsQuery Query { get; }
}
