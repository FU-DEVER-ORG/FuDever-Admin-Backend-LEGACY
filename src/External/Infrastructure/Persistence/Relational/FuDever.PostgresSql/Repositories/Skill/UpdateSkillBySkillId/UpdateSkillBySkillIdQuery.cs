﻿using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FuDever.Domain.Repositories.Skill.UpdateSkillBySkillId;
using FuDever.PostgresSql.Commons;
using FuDever.PostgresSql.Repositories.Skill.UpdateSkillBySkillId.Others;
using Microsoft.EntityFrameworkCore;

namespace FuDever.PostgresSql.Repositories.Skill.UpdateSkillBySkillId;

internal sealed class UpdateSkillBySkillIdQuery : IUpdateSkillBySkillIdQuery
{
    private readonly UpdateSkillBySkillIdStateBag _stateBag;

    internal UpdateSkillBySkillIdQuery(UpdateSkillBySkillIdStateBag stateBag)
    {
        _stateBag = stateBag;
    }

    public Task<Domain.Entities.Skill> FindSkillBySkillIdForCacheClearing(
        Guid skillId,
        CancellationToken cancellationToken
    )
    {
        return _stateBag
            .Skills.AsNoTracking()
            .Where(predicate: skill => skill.Id == skillId)
            .Select(selector: skill => new Domain.Entities.Skill { Name = skill.Name })
            .FirstOrDefaultAsync(cancellationToken: cancellationToken);
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

    public Task<bool> IsSkillFoundBySkillIdQueryAsync(
        Guid skillId,
        CancellationToken cancellationToken
    )
    {
        // Linq-Base
        return _stateBag.Skills.AnyAsync(
            skill => skill.Id == skillId,
            cancellationToken: cancellationToken
        );
    }

    public Task<bool> IsSkillTemporarilyRemovedBySkillIdQueryAsync(
        Guid skillId,
        CancellationToken cancellationToken
    )
    {
        // Linq-Base
        return _stateBag.Skills.AnyAsync(
            skill =>
                skill.RemovedBy
                    != Application.Shared.Commons.CommonConstant.App.DEFAULT_ENTITY_ID_AS_GUID
                && skill.RemovedAt != CommonConstant.DbDefaultValue.MIN_DATE_TIME,
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
