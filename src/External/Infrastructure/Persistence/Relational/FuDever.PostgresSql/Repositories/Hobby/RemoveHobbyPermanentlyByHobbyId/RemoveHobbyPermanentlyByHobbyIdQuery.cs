using System;
using System.Threading;
using System.Threading.Tasks;
using FuDever.Domain.Repositories.Hobby.RemoveHobbyPermanentlyByHobbyId;
using FuDever.PostgresSql.Commons;
using FuDever.PostgresSql.Repositories.Hobby.RemoveHobbyPermanentlyByHobbyId.Others;
using Microsoft.EntityFrameworkCore;

namespace FuDever.PostgresSql.Repositories.Hobby.RemoveHobbyPermanentlyByHobbyId;

internal sealed class RemoveHobbyPermanentlyByHobbyIdQuery : IRemoveHobbyPermanentlyByHobbyIdQuery
{
    private readonly RemoveHobbyPermanentlyByHobbyIdStateBag _stateBag;

    internal RemoveHobbyPermanentlyByHobbyIdQuery(RemoveHobbyPermanentlyByHobbyIdStateBag stateBag)
    {
        _stateBag = stateBag;
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
