using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FuDever.Domain.Entities;
using FuDever.Domain.Repositories.Admin.ApproveNewUser;
using FuDever.PostgresSql.Commons;
using FuDever.PostgresSql.Repositories.Admin.ApproveNewUser.Others;
using Microsoft.EntityFrameworkCore;

namespace FuDever.PostgresSql.Repositories.Admin.ApproveNewUser;

internal sealed class ApproveNewUserQuery : IApproveNewUserQuery
{
    private readonly ApproveNewUserStateBag _stateBag;

    internal ApproveNewUserQuery(ApproveNewUserStateBag stateBag)
    {
        _stateBag = stateBag;
    }

    public Task<UserJoiningStatus> GetApprovedUserJoiningStatusQueryAsync(
        CancellationToken cancellationToken
    )
    {
        return _stateBag
            .UserJoiningStatuses.AsNoTracking()
            .Where(predicate: userJoiningStatus => userJoiningStatus.Type.Equals("Approved"))
            .Select(selector: userJoiningStatus => new UserJoiningStatus
            {
                Id = userJoiningStatus.Id
            })
            .FirstOrDefaultAsync(cancellationToken: cancellationToken);
    }

    public Task<UserDetail> GetUserJoiningStatusQueryAsync(
        Guid userId,
        CancellationToken cancellationToken
    )
    {
        return _stateBag
            .UserDetails.AsNoTracking()
            .Where(predicate: userDetail => userDetail.Id == userId)
            .Select(selector: userDetail => new UserDetail
            {
                UserJoiningStatus = new() { Type = userDetail.UserJoiningStatus.Type }
            })
            .FirstOrDefaultAsync(cancellationToken: cancellationToken);
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

    public Task<bool> IsUserFoundByUserIdQueryAsync(
        Guid userId,
        CancellationToken cancellationToken
    )
    {
        return _stateBag.UserDetails.AnyAsync(
            predicate: user => user.Id == userId,
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
