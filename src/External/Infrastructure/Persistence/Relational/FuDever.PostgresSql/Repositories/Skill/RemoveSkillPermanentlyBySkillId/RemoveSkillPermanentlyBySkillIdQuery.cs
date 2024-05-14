using System;
using System.Threading;
using System.Threading.Tasks;
using FuDever.Domain.Repositories.Skill.RemoveSkillPermanentlyBySkillId;
using FuDever.PostgresSql.Commons;
using FuDever.PostgresSql.Repositories.Skill.RemoveSkillPermanentlyBySkillId.Others;
using Microsoft.EntityFrameworkCore;

namespace FuDever.PostgresSql.Repositories.Skill.RemoveSkillPermanentlyBySkillId;

internal sealed class RemoveSkillPermanentlyBySkillIdQuery : IRemoveSkillPermanentlyBySkillIdQuery
{
    private readonly RemoveSkillPermanentlyBySkillIdStateBag _stateBag;

    internal RemoveSkillPermanentlyBySkillIdQuery(RemoveSkillPermanentlyBySkillIdStateBag stateBag)
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
