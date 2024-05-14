using System;
using FuDever.Domain.Specifications.Base;
using FuDever.Domain.Specifications.Entities.UserSkill;

namespace FuDever.SqlServer.Specifications.Entities.UserSkill;

/// <summary>
///     Represent implementation of user skill by user
///     id specification.
/// </summary>
internal sealed class UserSkillByUserIdSpecification
    : BaseSpecification<Domain.Entities.UserSkill>,
        IUserSkillByUserIdSpecification
{
    internal UserSkillByUserIdSpecification(Guid userId)
    {
        WhereExpression = userSkill => userSkill.UserId == userId;
    }
}
