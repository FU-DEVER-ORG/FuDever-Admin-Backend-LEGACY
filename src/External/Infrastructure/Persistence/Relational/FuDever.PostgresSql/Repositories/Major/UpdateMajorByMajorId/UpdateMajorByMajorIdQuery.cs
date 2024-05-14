﻿using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FuDever.Domain.Repositories.Major.UpdateMajorByMajorId;
using FuDever.PostgresSql.Commons;
using FuDever.PostgresSql.Repositories.Major.UpdateMajorByMajorId.Others;
using Microsoft.EntityFrameworkCore;

namespace FuDever.PostgresSql.Repositories.Major.UpdateMajorByMajorId;

internal sealed class UpdateMajorByMajorIdQuery : IUpdateMajorByMajorIdQuery
{
    private readonly UpdateMajorByMajorIdStateBag _stateBag;

    internal UpdateMajorByMajorIdQuery(UpdateMajorByMajorIdStateBag stateBag)
    {
        _stateBag = stateBag;
    }

    public Task<Domain.Entities.Major> FindMajorByMajorIdForCacheClearing(
        Guid majorId,
        CancellationToken cancellationToken
    )
    {
        return _stateBag
            .Majors.AsNoTracking()
            .Where(predicate: major => major.Id == majorId)
            .Select(selector: major => new Domain.Entities.Major { Name = major.Name })
            .FirstOrDefaultAsync(cancellationToken: cancellationToken);
    }

    public Task<bool> IsMajorFoundByMajorIdQueryAsync(
        Guid majorId,
        CancellationToken cancellationToken
    )
    {
        // Linq-Base
        return _stateBag.Majors.AnyAsync(
            major => major.Id == majorId,
            cancellationToken: cancellationToken
        );
    }

    public Task<bool> IsMajorTemporarilyRemovedByMajorIdQueryAsync(
        Guid majorId,
        CancellationToken cancellationToken
    )
    {
        // Linq-Base
        return _stateBag.Majors.AnyAsync(
            major =>
                major.RemovedBy
                    != Application.Shared.Commons.CommonConstant.App.DEFAULT_ENTITY_ID_AS_GUID
                && major.RemovedAt != CommonConstant.DbDefaultValue.MIN_DATE_TIME,
            cancellationToken: cancellationToken
        );
    }

    public Task<bool> IsMajorWithTheSameNameFoundByMajorNameQueryAsync(
        string newMajorName,
        CancellationToken cancellationToken
    )
    {
        // Linq-Base
        return _stateBag.Majors.AnyAsync(
            predicate: major =>
                EF.Functions.Collate(major.Name, CommonConstant.DbCollation.CASE_INSENSITIVE)
                    .Equals(newMajorName),
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
