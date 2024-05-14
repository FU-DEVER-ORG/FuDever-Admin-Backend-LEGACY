using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FuDever.Domain.Repositories.Hobby.GetAllTemporarilyRemovedHobbies;
using FuDever.PostgresSql.Commons;
using FuDever.PostgresSql.Repositories.Hobby.GetAllTemporarilyRemovedHobbies.Others;
using Microsoft.EntityFrameworkCore;

namespace FuDever.PostgresSql.Repositories.Hobby.GetAllTemporarilyRemovedHobbies;

internal sealed class GetAllTemporarilyRemovedHobbiesQuery : IGetAllTemporarilyRemovedHobbiesQuery
{
    private readonly GetAllTemporarilyRemovedHobbiesStateBag _stateBag;

    internal GetAllTemporarilyRemovedHobbiesQuery(GetAllTemporarilyRemovedHobbiesStateBag stateBag)
    {
        _stateBag = stateBag;
    }

    public async Task<IEnumerable<Domain.Entities.Hobby>> GetAllTemporarilyRemovedHobbiesQueryAsync(
        CancellationToken cancellationToken
    )
    {
        // Linq-base
        return await _stateBag
            .Hobbies.AsNoTracking()
            .Where(predicate: hobby =>
                hobby.RemovedAt != CommonConstant.DbDefaultValue.MIN_DATE_TIME
                && hobby.RemovedBy
                    != Application.Shared.Commons.CommonConstant.App.DEFAULT_ENTITY_ID_AS_GUID
                && hobby.Id
                    != Application.Shared.Commons.CommonConstant.App.DEFAULT_ENTITY_ID_AS_GUID
            )
            .Select(hobby => new Domain.Entities.Hobby
            {
                Id = hobby.Id,
                Name = hobby.Name,
                RemovedAt = hobby.RemovedAt,
                RemovedBy = hobby.RemovedBy
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
