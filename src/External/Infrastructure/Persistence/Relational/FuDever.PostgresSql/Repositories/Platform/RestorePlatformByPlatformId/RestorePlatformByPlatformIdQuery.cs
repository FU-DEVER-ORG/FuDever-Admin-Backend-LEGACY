using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FuDever.Domain.Repositories.Platform.RestorePlatformByPlatformId;
using FuDever.PostgresSql.Commons;
using FuDever.PostgresSql.Repositories.Platform.RestorePlatformByPlatformId.Others;
using Microsoft.EntityFrameworkCore;

namespace FuDever.PostgresSql.Repositories.Platform.RestorePlatformByPlatformId;

internal sealed class RestorePlatformByPlatformIdQuery : IRestorePlatformByPlatformIdQuery
{
    private readonly RestorePlatformByPlatformIdStateBag _stateBag;

    internal RestorePlatformByPlatformIdQuery(RestorePlatformByPlatformIdStateBag stateBag)
    {
        _stateBag = stateBag;
    }

    public Task<Domain.Entities.Platform> FindPlatformByPlatformIdForCacheClearing(
        Guid platformId,
        CancellationToken cancellationToken
    )
    {
        return _stateBag
            .Platforms.AsNoTracking()
            .Where(predicate: platform => platform.Id == platformId)
            .Select(selector: platform => new Domain.Entities.Platform { Name = platform.Name })
            .FirstOrDefaultAsync(cancellationToken: cancellationToken);
    }

    public Task<bool> IsPlatformFoundByPlatformIdQueryAsync(
        Guid platformId,
        CancellationToken cancellationToken
    )
    {
        // Linq-Base
        return _stateBag.Platforms.AnyAsync(
            platform => platform.Id == platformId,
            cancellationToken: cancellationToken
        );
    }

    public Task<bool> IsPlatformTemporarilyRemovedByPlatformIdQueryAsync(
        Guid platformId,
        CancellationToken cancellationToken
    )
    {
        // Linq-Base
        return _stateBag.Platforms.AnyAsync(
            platform =>
                platform.RemovedBy
                    != Application.Shared.Commons.CommonConstant.App.DEFAULT_ENTITY_ID_AS_GUID
                && platform.RemovedAt != CommonConstant.DbDefaultValue.MIN_DATE_TIME,
            cancellationToken: cancellationToken
        );
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
