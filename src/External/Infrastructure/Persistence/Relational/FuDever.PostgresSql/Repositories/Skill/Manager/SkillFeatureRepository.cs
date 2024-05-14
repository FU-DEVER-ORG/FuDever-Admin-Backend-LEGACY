using FuDever.Domain.Repositories.Skill.CreateSkill;
using FuDever.Domain.Repositories.Skill.GetAllSkills;
using FuDever.Domain.Repositories.Skill.GetAllSkillsBySkillName;
using FuDever.Domain.Repositories.Skill.GetAllTemporarilyRemovedSkills;
using FuDever.Domain.Repositories.Skill.Manager;
using FuDever.Domain.Repositories.Skill.RemoveSkillPermanentlyBySkillId;
using FuDever.Domain.Repositories.Skill.RemoveSkillTemporarilyBySkillId;
using FuDever.Domain.Repositories.Skill.RestoreSkillBySkillId;
using FuDever.Domain.Repositories.Skill.UpdateSkillBySkillId;
using FuDever.PostgresSql.Data;
using FuDever.PostgresSql.Repositories.Skill.CreateSkill.Others;
using FuDever.PostgresSql.Repositories.Skill.GetAllSkills.Others;
using FuDever.PostgresSql.Repositories.Skill.GetAllSkillsBySkillName.Others;
using FuDever.PostgresSql.Repositories.Skill.GetAllTemporarilyRemovedSkills.Others;
using FuDever.PostgresSql.Repositories.Skill.RemoveSkillPermanentlyBySkillId.Others;
using FuDever.PostgresSql.Repositories.Skill.RemoveSkillTemporarilyBySkillId.Others;
using FuDever.PostgresSql.Repositories.Skill.RestoreSkillBySkillId.Others;
using FuDever.PostgresSql.Repositories.Skill.UpdateSkillBySkillId.Others;

namespace FuDever.PostgresSql.Repositories.Skill.Manager;

internal sealed class SkillFeatureRepository : ISkillFeatureRepository
{
    private ICreateSkillRepository _createSkillRepository;
    private IGetAllSkillsRepository _getAllSkillsRepository;
    private IGetAllSkillsBySkillNameRepository _getAllSkillsBySkillNameRepository;
    private IGetAllTemporarilyRemovedSkillsRepository _getAllTemporarilyRemovedSkillsRepository;
    private IRemoveSkillPermanentlyBySkillIdRepository _removeSkillPermanentlyBySkillIdRepository;
    private IRemoveSkillTemporarilyBySkillIdRepository _removeSkillTemporarilyBySkillIdRepository;
    private IRestoreSkillBySkillIdRepository _restoreSkillBySkillIdRepository;
    private IUpdateSkillBySkillIdRepository _updateSkillBySkillIdRepository;
    private readonly FuDeverContext _context;

    internal SkillFeatureRepository(FuDeverContext context)
    {
        _context = context;
    }

    public ICreateSkillRepository CreateSkill
    {
        get { return _createSkillRepository ??= new CreateSkillRepository(context: _context); }
    }

    public IGetAllSkillsRepository GetAllSkills
    {
        get { return _getAllSkillsRepository ??= new GetAllSkillsRepository(context: _context); }
    }

    public IGetAllSkillsBySkillNameRepository GetAllSkillsBySkillName
    {
        get
        {
            return _getAllSkillsBySkillNameRepository ??= new GetAllSkillsBySkillNameRepository(
                context: _context
            );
        }
    }

    public IGetAllTemporarilyRemovedSkillsRepository GetAllTemporarilyRemovedSkills
    {
        get
        {
            return _getAllTemporarilyRemovedSkillsRepository ??=
                new GetAllTemporarilyRemovedSkillsRepository(context: _context);
        }
    }

    public IRemoveSkillPermanentlyBySkillIdRepository RemoveSkillPermanentlyBySkillId
    {
        get
        {
            return _removeSkillPermanentlyBySkillIdRepository ??=
                new RemoveSkillPermanentlyBySkillIdRepository(context: _context);
        }
    }

    public IRemoveSkillTemporarilyBySkillIdRepository RemoveSkillTemporarilyBySkillId
    {
        get
        {
            return _removeSkillTemporarilyBySkillIdRepository ??=
                new RemoveSkillTemporarilyBySkillIdRepository(context: _context);
        }
    }

    public IRestoreSkillBySkillIdRepository RestoreSkillBySkillId
    {
        get
        {
            return _restoreSkillBySkillIdRepository ??= new RestoreSkillBySkillIdRepository(
                context: _context
            );
        }
    }

    public IUpdateSkillBySkillIdRepository UpdateSkillBySkillId
    {
        get
        {
            return _updateSkillBySkillIdRepository ??= new UpdateSkillBySkillIdRepository(
                context: _context
            );
        }
    }
}
