using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FuDever.Domain.Entities;
using FuDever.Domain.Repositories.Auth.RefreshAccessToken;
using FuDever.PostgresSql.Commons;
using FuDever.PostgresSql.Repositories.Auth.RefreshAccessToken.Others;
using Microsoft.EntityFrameworkCore;

namespace FuDever.PostgresSql.Repositories.Auth.RefreshAccessToken;

internal sealed class RefreshAccessTokenQuery : IRefreshAccessTokenQuery
{
    private readonly RefreshAccessTokenStateBag _stateBag;

    internal RefreshAccessTokenQuery(RefreshAccessTokenStateBag stateBag)
    {
        _stateBag = stateBag;
    }

    public Task<RefreshToken> FindByRefreshTokenValueQueryAsync(
        string refreshTokenValue,
        CancellationToken cancellationToken
    )
    {
        return _stateBag
            .RefreshTokens.AsNoTracking()
            .Where(predicate: refreshToken =>
                refreshToken.RefreshTokenValue.Equals(refreshTokenValue)
            )
            .Select(selector: refreshToken => new RefreshToken
            {
                ExpiredDate = refreshToken.ExpiredDate
            })
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
