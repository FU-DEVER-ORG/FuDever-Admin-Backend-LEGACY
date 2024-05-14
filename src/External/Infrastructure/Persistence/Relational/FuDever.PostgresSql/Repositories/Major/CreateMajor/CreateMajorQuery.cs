using System;
using System.Threading;
using System.Threading.Tasks;
using FuDever.Domain.Repositories.Major.CreateMajor;
using FuDever.PostgresSql.Commons;
using FuDever.PostgresSql.Repositories.Major.CreateMajor.Others;
using Microsoft.EntityFrameworkCore;

namespace FuDever.PostgresSql.Repositories.Major.CreateMajor;

internal sealed class CreateMajorQuery : ICreateMajorQuery
{
    private readonly CreateMajorStateBag _stateBag;

    internal CreateMajorQuery(CreateMajorStateBag stateBag)
    {
        _stateBag = stateBag;
    }

    public Task<bool> IsMajorTemporarilyRemovedByMajorNameQueryAsync(
        string newMajorName,
        CancellationToken cancellationToken
    )
    {
        var minDateTimeInDatabase = CommonConstant.DbDefaultValue.MIN_DATE_TIME;

        // Linq-Base
        return _stateBag.Majors.AnyAsync(
            predicate: major =>
                EF.Functions.Collate(major.Name, CommonConstant.DbCollation.CASE_INSENSITIVE)
                    .Equals(newMajorName)
                && major.RemovedBy
                    != Application.Shared.Commons.CommonConstant.App.DEFAULT_ENTITY_ID_AS_GUID
                && major.RemovedAt != minDateTimeInDatabase,
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
