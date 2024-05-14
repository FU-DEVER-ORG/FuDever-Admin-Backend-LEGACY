using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FuDever.Domain.Repositories.Position.RemovePositionTemporarilyByPositionId;
using FuDever.PostgresSql.Commons;
using FuDever.PostgresSql.Repositories.Position.RemovePositionTemporarilyByPositionId.Others;
using Microsoft.EntityFrameworkCore;

namespace FuDever.PostgresSql.Repositories.Position.RemovePositionTemporarilyByPositionId;

internal sealed class RemovePositionTemporarilyByPositionIdQuery
    : IRemovePositionTemporarilyByPositionIdQuery
{
    private readonly RemovePositionTemporarilyByPositionIdStateBag _stateBag;

    internal RemovePositionTemporarilyByPositionIdQuery(
        RemovePositionTemporarilyByPositionIdStateBag stateBag
    )
    {
        _stateBag = stateBag;
    }

    public Task<Domain.Entities.Position> FindPositionByPositionIdForCacheClearing(
        Guid positionId,
        CancellationToken cancellationToken
    )
    {
        return _stateBag
            .Positions.AsNoTracking()
            .Where(predicate: position => position.Id == positionId)
            .Select(selector: position => new Domain.Entities.Position { Name = position.Name })
            .FirstOrDefaultAsync(cancellationToken: cancellationToken);
    }

    public Task<bool> IsPositionFoundByPositionIdQueryAsync(
        Guid positionId,
        CancellationToken cancellationToken
    )
    {
        // Linq-Base
        return _stateBag.Positions.AnyAsync(
            position => position.Id == positionId,
            cancellationToken: cancellationToken
        );
    }

    public Task<bool> IsPositionTemporarilyRemovedByPositionIdQueryAsync(
        Guid positionId,
        CancellationToken cancellationToken
    )
    {
        // Linq-Base
        return _stateBag.Positions.AnyAsync(
            position =>
                position.RemovedBy
                    != Application.Shared.Commons.CommonConstant.App.DEFAULT_ENTITY_ID_AS_GUID
                && position.RemovedAt != CommonConstant.DbDefaultValue.MIN_DATE_TIME,
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
