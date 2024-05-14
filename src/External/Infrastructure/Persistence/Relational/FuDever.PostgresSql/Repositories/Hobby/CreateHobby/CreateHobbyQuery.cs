using System;
using System.Threading;
using System.Threading.Tasks;
using FuDever.Domain.Repositories.Hobby.CreateHobby;
using FuDever.PostgresSql.Commons;
using FuDever.PostgresSql.Repositories.Hobby.CreateHobby.Others;
using Microsoft.EntityFrameworkCore;

namespace FuDever.PostgresSql.Repositories.Hobby.CreateHobby;

internal sealed class CreateHobbyQuery : ICreateHobbyQuery
{
    private readonly CreateHobbyStateBag _stateBag;

    internal CreateHobbyQuery(CreateHobbyStateBag stateBag)
    {
        _stateBag = stateBag;
    }

    public Task<bool> IsHobbyTemporarilyRemovedByHobbyNameQueryAsync(
        string newHobbyName,
        CancellationToken cancellationToken
    )
    {
        var minDateTimeInDatabase = CommonConstant.DbDefaultValue.MIN_DATE_TIME;

        // Linq-Base
        return _stateBag.Hobbies.AnyAsync(
            predicate: hobby =>
                EF.Functions.Collate(hobby.Name, CommonConstant.DbCollation.CASE_INSENSITIVE)
                    .Equals(newHobbyName)
                && hobby.RemovedBy
                    != Application.Shared.Commons.CommonConstant.App.DEFAULT_ENTITY_ID_AS_GUID
                && hobby.RemovedAt != minDateTimeInDatabase,
            cancellationToken: cancellationToken
        );
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
