using System;
using System.Threading;
using System.Threading.Tasks;
using FuDever.Domain.Repositories.Platform.CreatePlatform;
using FuDever.PostgresSql.Commons;
using FuDever.PostgresSql.Repositories.Platform.CreatePlatform.Others;
using Microsoft.EntityFrameworkCore;

namespace FuDever.PostgresSql.Repositories.Platform.CreatePlatform;

internal sealed class CreatePlatformQuery : ICreatePlatformQuery
{
    private readonly CreatePlatformStateBag _stateBag;

    internal CreatePlatformQuery(CreatePlatformStateBag stateBag)
    {
        _stateBag = stateBag;
    }

    public Task<bool> IsPlatformTemporarilyRemovedByPlatformNameQueryAsync(
        string newPlatformName,
        CancellationToken cancellationToken
    )
    {
        var minDateTimeInDatabase = CommonConstant.DbDefaultValue.MIN_DATE_TIME;

        // Linq-Base
        return _stateBag.Platforms.AnyAsync(
            predicate: platform =>
                EF.Functions.Collate(platform.Name, CommonConstant.DbCollation.CASE_INSENSITIVE)
                    .Equals(newPlatformName)
                && platform.RemovedBy
                    != Application.Shared.Commons.CommonConstant.App.DEFAULT_ENTITY_ID_AS_GUID
                && platform.RemovedAt != minDateTimeInDatabase,
            cancellationToken: cancellationToken
        );
    }

    public Task<bool> IsPlatformWithTheSameNameFoundByPlatformNameQueryAsync(
        string newPlatformName,
        CancellationToken cancellationToken
    )
    {
        // Linq-Base
        return _stateBag.Platforms.AnyAsync(
            predicate: platform =>
                EF.Functions.Collate(platform.Name, CommonConstant.DbCollation.CASE_INSENSITIVE)
                    .Equals(newPlatformName),
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
