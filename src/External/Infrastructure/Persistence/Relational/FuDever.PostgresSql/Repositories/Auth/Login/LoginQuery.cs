using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FuDever.Domain.Entities;
using FuDever.Domain.Repositories.Auth.Login;
using FuDever.PostgresSql.Commons;
using FuDever.PostgresSql.Repositories.Auth.Login.Others;
using Microsoft.EntityFrameworkCore;

namespace FuDever.PostgresSql.Repositories.Auth.Login;

internal sealed class LoginQuery : ILoginQuery
{
    private readonly LoginStateBag _stateBag;

    internal LoginQuery(LoginStateBag stateBag)
    {
        _stateBag = stateBag;
    }

    public async Task<string> GetUserAvatarUrlQueryAsync(
        Guid userId,
        CancellationToken cancellationToken
    )
    {
        var foundUser = await _stateBag
            .UserDetails.AsNoTracking()
            .Where(predicate: userDetail => userDetail.Id == userId)
            .Select(selector: userDetail => new UserDetail { AvatarUrl = userDetail.AvatarUrl })
            .FirstOrDefaultAsync(cancellationToken: cancellationToken);

        return foundUser.AvatarUrl ?? string.Empty;
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
