using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FuDever.Domain.Repositories.Position.GetAllTemporarilyRemovedPositions;
using FuDever.PostgresSql.Commons;
using FuDever.PostgresSql.Repositories.Position.GetAllTemporarilyRemovedPositions.Others;
using Microsoft.EntityFrameworkCore;

namespace FuDever.PostgresSql.Repositories.Position.GetAllTemporarilyRemovedPositions;

internal sealed class GetAllTemporarilyRemovedPositionsQuery
    : IGetAllTemporarilyRemovedPositionsQuery
{
    private readonly GetAllTemporarilyRemovedPositionsStateBag _stateBag;

    internal GetAllTemporarilyRemovedPositionsQuery(
        GetAllTemporarilyRemovedPositionsStateBag stateBag
    )
    {
        _stateBag = stateBag;
    }

    public async Task<
        IEnumerable<Domain.Entities.Position>
    > GetAllTemporarilyRemovedPositionsQueryAsync(CancellationToken cancellationToken)
    {
        // Linq-base
        return await _stateBag
            .Positions.AsNoTracking()
            .Where(predicate: position =>
                position.RemovedAt != CommonConstant.DbDefaultValue.MIN_DATE_TIME
                && position.RemovedBy
                    != Application.Shared.Commons.CommonConstant.App.DEFAULT_ENTITY_ID_AS_GUID
                && position.Id
                    != Application.Shared.Commons.CommonConstant.App.DEFAULT_ENTITY_ID_AS_GUID
            )
            .Select(selector: position => new Domain.Entities.Position
            {
                Id = position.Id,
                Name = position.Name,
                RemovedAt = position.RemovedAt,
                RemovedBy = position.RemovedBy
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
