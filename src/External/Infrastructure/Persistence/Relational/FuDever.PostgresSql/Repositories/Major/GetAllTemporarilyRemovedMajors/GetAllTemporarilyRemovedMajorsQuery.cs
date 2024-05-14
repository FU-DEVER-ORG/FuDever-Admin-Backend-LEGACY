using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FuDever.Domain.Repositories.Major.GetAllTemporarilyRemovedMajors;
using FuDever.PostgresSql.Commons;
using FuDever.PostgresSql.Repositories.Major.GetAllTemporarilyRemovedMajors.Others;
using Microsoft.EntityFrameworkCore;

namespace FuDever.PostgresSql.Repositories.Major.GetAllTemporarilyRemovedMajors;

internal sealed class GetAllTemporarilyRemovedMajorsQuery : IGetAllTemporarilyRemovedMajorsQuery
{
    private readonly GetAllTemporarilyRemovedMajorsStateBag _stateBag;

    internal GetAllTemporarilyRemovedMajorsQuery(GetAllTemporarilyRemovedMajorsStateBag stateBag)
    {
        _stateBag = stateBag;
    }

    public async Task<IEnumerable<Domain.Entities.Major>> GetAllTemporarilyRemovedMajorsQueryAsync(
        CancellationToken cancellationToken
    )
    {
        // Linq-base
        return await _stateBag
            .Majors.AsNoTracking()
            .Where(predicate: major =>
                major.RemovedAt != CommonConstant.DbDefaultValue.MIN_DATE_TIME
                && major.RemovedBy
                    != Application.Shared.Commons.CommonConstant.App.DEFAULT_ENTITY_ID_AS_GUID
                && major.Id
                    != Application.Shared.Commons.CommonConstant.App.DEFAULT_ENTITY_ID_AS_GUID
            )
            .Select(selector: major => new Domain.Entities.Major
            {
                Id = major.Id,
                Name = major.Name,
                RemovedAt = major.RemovedAt,
                RemovedBy = major.RemovedBy
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
