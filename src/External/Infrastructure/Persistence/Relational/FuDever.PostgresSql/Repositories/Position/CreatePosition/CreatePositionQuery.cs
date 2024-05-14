using System;
using System.Threading;
using System.Threading.Tasks;
using FuDever.Domain.Repositories.Position.CreatePosition;
using FuDever.PostgresSql.Commons;
using FuDever.PostgresSql.Repositories.Position.CreatePosition.Others;
using Microsoft.EntityFrameworkCore;

namespace FuDever.PostgresSql.Repositories.Position.CreatePosition;

internal sealed class CreatePositionQuery : ICreatePositionQuery
{
    private readonly CreatePositionStateBag _stateBag;

    internal CreatePositionQuery(CreatePositionStateBag stateBag)
    {
        _stateBag = stateBag;
    }

    public Task<bool> IsPositionTemporarilyRemovedByPositionNameQueryAsync(
        string newPositionName,
        CancellationToken cancellationToken
    )
    {
        var minDateTimeInDatabase = CommonConstant.DbDefaultValue.MIN_DATE_TIME;

        // Linq-Base
        return _stateBag.Positions.AnyAsync(
            predicate: position =>
                EF.Functions.Collate(position.Name, CommonConstant.DbCollation.CASE_INSENSITIVE)
                    .Equals(newPositionName)
                && position.RemovedBy
                    != Application.Shared.Commons.CommonConstant.App.DEFAULT_ENTITY_ID_AS_GUID
                && position.RemovedAt != minDateTimeInDatabase,
            cancellationToken: cancellationToken
        );
    }

    public Task<bool> IsPositionWithTheSameNameFoundByPositionNameQueryAsync(
        string newPositionName,
        CancellationToken cancellationToken
    )
    {
        // Linq-Base
        return _stateBag.Positions.AnyAsync(
            predicate: position =>
                EF.Functions.Collate(position.Name, CommonConstant.DbCollation.CASE_INSENSITIVE)
                    .Equals(newPositionName),
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
