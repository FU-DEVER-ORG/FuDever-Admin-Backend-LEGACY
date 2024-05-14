using FuDever.Domain.Repositories.Skill.CreateSkill;
using FuDever.Domain.Repositories.Skill.GetAllSkills;
using FuDever.Domain.Repositories.Skill.GetAllSkillsBySkillName;
using FuDever.Domain.Repositories.Skill.GetAllTemporarilyRemovedSkills;
using FuDever.Domain.Repositories.Skill.RemoveSkillPermanentlyBySkillId;
using FuDever.Domain.Repositories.Skill.RemoveSkillTemporarilyBySkillId;
using FuDever.Domain.Repositories.Skill.RestoreSkillBySkillId;
using FuDever.Domain.Repositories.Skill.UpdateSkillBySkillId;

namespace FuDever.Domain.Repositories.Skill.Manager;

public interface ISkillFeatureRepository
{
    ICreateSkillRepository CreateSkill { get; }

    IGetAllSkillsRepository GetAllSkills { get; }

    IGetAllSkillsBySkillNameRepository GetAllSkillsBySkillName { get; }

    IGetAllTemporarilyRemovedSkillsRepository GetAllTemporarilyRemovedSkills { get; }

    IRemoveSkillPermanentlyBySkillIdRepository RemoveSkillPermanentlyBySkillId { get; }

    IRemoveSkillTemporarilyBySkillIdRepository RemoveSkillTemporarilyBySkillId { get; }

    IRestoreSkillBySkillIdRepository RestoreSkillBySkillId { get; }

    IUpdateSkillBySkillIdRepository UpdateSkillBySkillId { get; }
}
