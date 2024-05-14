﻿using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FuDever.Domain.Repositories.Hobby.UpdateHobbyByHobbyId;
using FuDever.PostgresSql.Commons;
using FuDever.PostgresSql.Repositories.Hobby.UpdateHobbyByHobbyId.Others;
using Microsoft.EntityFrameworkCore;

namespace FuDever.PostgresSql.Repositories.Hobby.UpdateHobbyByHobbyId;

internal sealed class UpdateHobbyByHobbyIdQuery : IUpdateHobbyByHobbyIdQuery
{
    private readonly UpdateHobbyByHobbyIdStateBag _stateBag;

    internal UpdateHobbyByHobbyIdQuery(UpdateHobbyByHobbyIdStateBag stateBag)
    {
        _stateBag = stateBag;
    }

    public Task<Domain.Entities.Hobby> FindHobbyByHobbyIdForCacheClearing(
        Guid hobbyId,
        CancellationToken cancellationToken
    )
    {
        return _stateBag
            .Hobbies.AsNoTracking()
            .Where(predicate: hobby => hobby.Id == hobbyId)
            .Select(selector: hobby => new Domain.Entities.Hobby { Name = hobby.Name })
            .FirstOrDefaultAsync(cancellationToken: cancellationToken);
    }

    public Task<bool> IsHobbyWithTheSameNameFoundByHobbyNameQueryAsync(
        string newHobbyName,
        CancellationToken cancellationToken
    )
    {
        // Linq-Base
        return _stateBag.Hobbies.AnyAsync(
            predicate: hobby =>
                EF.Functions.Collate(hobby.Name, CommonConstant.DbCollation.CASE_INSENSITIVE)
                    .Equals(newHobbyName),
            cancellationToken: cancellationToken
        );
    }

    public Task<bool> IsHobbyFoundByHobbyIdQueryAsync(
        Guid hobbyId,
        CancellationToken cancellationToken
    )
    {
        // Linq-Base
        return _stateBag.Hobbies.AnyAsync(
            hobby => hobby.Id == hobbyId,
            cancellationToken: cancellationToken
        );
    }

    public Task<bool> IsHobbyTemporarilyRemovedByHobbyIdQueryAsync(
        Guid hobbyId,
        CancellationToken cancellationToken
    )
    {
        // Linq-Base
        return _stateBag.Hobbies.AnyAsync(
            hobby =>
                hobby.RemovedBy
                    != Application.Shared.Commons.CommonConstant.App.DEFAULT_ENTITY_ID_AS_GUID
                && hobby.RemovedAt != CommonConstant.DbDefaultValue.MIN_DATE_TIME,
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
