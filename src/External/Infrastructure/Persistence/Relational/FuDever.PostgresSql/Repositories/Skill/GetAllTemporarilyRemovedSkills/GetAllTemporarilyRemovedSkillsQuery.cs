using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FuDever.Domain.Repositories.Skill.GetAllTemporarilyRemovedSkills;
using FuDever.PostgresSql.Commons;
using FuDever.PostgresSql.Repositories.Skill.GetAllTemporarilyRemovedSkills.Others;
using Microsoft.EntityFrameworkCore;

namespace FuDever.PostgresSql.Repositories.Skill.GetAllTemporarilyRemovedSkills;

internal sealed class GetAllTemporarilyRemovedSkillsQuery : IGetAllTemporarilyRemovedSkillsQuery
{
    private readonly GetAllTemporarilyRemovedSkillsStateBag _stateBag;

    internal GetAllTemporarilyRemovedSkillsQuery(GetAllTemporarilyRemovedSkillsStateBag stateBag)
    {
        _stateBag = stateBag;
    }

    public async Task<IEnumerable<Domain.Entities.Skill>> GetAllTemporarilyRemovedSkillsQueryAsync(
        CancellationToken cancellationToken
    )
    {
        // Linq-base
        return await _stateBag
            .Skills.AsNoTracking()
            .Where(predicate: skill =>
                skill.RemovedAt != CommonConstant.DbDefaultValue.MIN_DATE_TIME
                && skill.RemovedBy
                    != Application.Shared.Commons.CommonConstant.App.DEFAULT_ENTITY_ID_AS_GUID
                && skill.Id
                    != Application.Shared.Commons.CommonConstant.App.DEFAULT_ENTITY_ID_AS_GUID
            )
            .Select(selector: skill => new Domain.Entities.Skill
            {
                Id = skill.Id,
                Name = skill.Name,
                RemovedAt = skill.RemovedAt,
                RemovedBy = skill.RemovedBy
            })
            .ToListAsync(cancellationToken: cancellationToken);
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
