using System;
using System.Threading;
using System.Threading.Tasks;
using FuDever.Domain.Repositories.Skill.CreateSkill;
using FuDever.PostgresSql.Commons;
using FuDever.PostgresSql.Repositories.Skill.CreateSkill.Others;
using Microsoft.EntityFrameworkCore;

namespace FuDever.PostgresSql.Repositories.Skill.CreateSkill;

internal sealed class CreateSkillQuery : ICreateSkillQuery
{
    private readonly CreateSkillStateBag _stateBag;

    internal CreateSkillQuery(CreateSkillStateBag stateBag)
    {
        _stateBag = stateBag;
    }

    public Task<bool> IsRefreshTokenFoundByAccessTokenIdQueryAsync(
        Guid accessTokenId,
        CancellationToken cancellationToken
    )
    {
        // Linq-Base
        return _stateBag.RefreshTokens.AnyAsync(
            predicate: refreshToken => refreshToken.AccessTokenId == accessTokenId,
            cancellationToken: cancellationToken
        );
    }

    public Task<bool> IsSkillTemporarilyRemovedBySkillNameQueryAsync(
        string newSkillName,
        CancellationToken cancellationToken
    )
    {
        var minDateTimeInDatabase = CommonConstant.DbDefaultValue.MIN_DATE_TIME;

        // Linq-Base
        return _stateBag.Skills.AnyAsync(
            predicate: skill =>
                EF.Functions.Collate(skill.Name, CommonConstant.DbCollation.CASE_INSENSITIVE)
                    .Equals(newSkillName)
                && skill.RemovedBy
                    != Application.Shared.Commons.CommonConstant.App.DEFAULT_ENTITY_ID_AS_GUID
                && skill.RemovedAt != minDateTimeInDatabase,
            cancellationToken: cancellationToken
        );
    }

    public Task<bool> IsSkillWithTheSameNameFoundBySkillNameQueryAsync(
        string newSkillName,
        CancellationToken cancellationToken
    )
    {
        // Linq-Base
        return _stateBag.Skills.AnyAsync(
            predicate: skill =>
                EF.Functions.Collate(skill.Name, CommonConstant.DbCollation.CASE_INSENSITIVE)
                    .Equals(newSkillName),
            cancellationToken: cancellationToken
        );
    }

    public Task<bool> IsUserNotTemporarilyRemovedQueryAsync(
        Guid userId,
        CancellationToken cancellationToken
    )
    {
        var minDateTimeInDatabase = CommonConstant.DbDefaultValue.MIN_DATE_TIME;

        // Linq-Base
        return _stateBag.UserDetails.AnyAsync(
            predicate: user =>
                user.Id == userId
                && user.RemovedBy
                    == Application.Shared.Commons.CommonConstant.App.DEFAULT_ENTITY_ID_AS_GUID
                && user.RemovedAt == minDateTimeInDatabase,
            cancellationToken: cancellationToken
        );
    }
}
