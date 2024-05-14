using System;
using FuDever.Domain.Specifications.Entities.Skill;
using FuDever.Domain.Specifications.Entities.Skill.Manager;

namespace FuDever.SqlServer.Specifications.Entities.Skill.Manager;

/// <summary>
///     Represent implementation of skill specification manager.
/// </summary>
internal sealed class SkillSpecificationManager : ISkillSpecificationManager
{
    // Backing fields
    private ISkillNotTemporarilyRemovedSpecification _skillNotTemporarilyRemovedSpecification;
    private ISkillTemporarilyRemovedSpecification _skillTemporarilyRemovedSpecification;
    private ISkillAsNoTrackingSpecification _skillAsNoTrackingSpecification;
    private ISelectFieldsFromSkillSpecification _selectFieldsFromSkillSpecification;
    private IUpdateFieldOfSkillSpecification _updateFieldOfSkillSpecification;
    private ISkillNameIsNotDefaultSpecification _skillNameIsNotDefaultSpecification;

    public ISkillNotTemporarilyRemovedSpecification SkillNotTemporarilyRemovedSpecification
    {
        get
        {
            _skillNotTemporarilyRemovedSpecification ??=
                new SkillNotTemporarilyRemovedSpecification();

            return _skillNotTemporarilyRemovedSpecification;
        }
    }

    public ISkillTemporarilyRemovedSpecification SkillTemporarilyRemovedSpecification
    {
        get
        {
            _skillTemporarilyRemovedSpecification ??= new SkillTemporarilyRemovedSpecification();

            return _skillTemporarilyRemovedSpecification;
        }
    }

    public ISkillAsNoTrackingSpecification SkillAsNoTrackingSpecification
    {
        get
        {
            _skillAsNoTrackingSpecification ??= new SkillAsNoTrackingSpecification();

            return _skillAsNoTrackingSpecification;
        }
    }

    public ISelectFieldsFromSkillSpecification SelectFieldsFromSkillSpecification
    {
        get
        {
            _selectFieldsFromSkillSpecification ??= new SelectFieldsFromSkillSpecification();

            return _selectFieldsFromSkillSpecification;
        }
    }

    public IUpdateFieldOfSkillSpecification UpdateFieldOfSkillSpecification
    {
        get
        {
            _updateFieldOfSkillSpecification ??= new UpdateFieldOfSkillSpecification();

            return _updateFieldOfSkillSpecification;
        }
    }

    public ISkillNameIsNotDefaultSpecification SkillNameIsNotDefaultSpecification
    {
        get
        {
            _skillNameIsNotDefaultSpecification ??= new SkillNameIsNotDefaultSpecification();

            return _skillNameIsNotDefaultSpecification;
        }
    }

    public ISkillByIdSpecification SkillByIdSpecification(Guid skillId)
    {
        return new SkillByIdSpecification(skillId: skillId);
    }

    public ISkillByNameSpecification SkillByNameSpecification(
        string skillName,
        bool isCaseSensitive
    )
    {
        return new SkillByNameSpecification(skillName: skillName, isCaseSensitive: isCaseSensitive);
    }
}
