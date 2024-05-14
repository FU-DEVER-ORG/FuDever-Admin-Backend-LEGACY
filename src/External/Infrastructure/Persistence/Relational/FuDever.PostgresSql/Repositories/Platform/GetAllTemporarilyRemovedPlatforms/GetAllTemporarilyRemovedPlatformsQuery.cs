using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FuDever.Domain.Repositories.Platform.GetAllTemporarilyRemovedPlatforms;
using FuDever.PostgresSql.Commons;
using FuDever.PostgresSql.Repositories.Platform.GetAllTemporarilyRemovedPlatforms.Others;
using Microsoft.EntityFrameworkCore;

namespace FuDever.PostgresSql.Repositories.Platform.GetAllTemporarilyRemovedPlatforms;

internal sealed class GetAllTemporarilyRemovedPlatformsQuery
    : IGetAllTemporarilyRemovedPlatformsQuery
{
    private readonly GetAllTemporarilyRemovedPlatformsStateBag _stateBag;

    internal GetAllTemporarilyRemovedPlatformsQuery(
        GetAllTemporarilyRemovedPlatformsStateBag stateBag
    )
    {
        _stateBag = stateBag;
    }

    public async Task<
        IEnumerable<Domain.Entities.Platform>
    > GetAllTemporarilyRemovedPlatformsQueryAsync(CancellationToken cancellationToken)
    {
        // Linq-base
        return await _stateBag
            .Platforms.AsNoTracking()
            .Where(predicate: platform =>
                platform.RemovedAt != CommonConstant.DbDefaultValue.MIN_DATE_TIME
                && platform.RemovedBy
                    != Application.Shared.Commons.CommonConstant.App.DEFAULT_ENTITY_ID_AS_GUID
                && platform.Id
                    != Application.Shared.Commons.CommonConstant.App.DEFAULT_ENTITY_ID_AS_GUID
            )
            .Select(selector: platform => new Domain.Entities.Platform
            {
                Id = platform.Id,
                Name = platform.Name,
                RemovedAt = platform.RemovedAt,
                RemovedBy = platform.RemovedBy
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
