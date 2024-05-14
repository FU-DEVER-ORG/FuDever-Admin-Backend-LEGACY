using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FuDever.Domain.Entities;
using FuDever.Domain.Repositories.Auth.ChangingPassword;
using FuDever.PostgresSql.Commons;
using FuDever.PostgresSql.Repositories.Auth.ChangingPassword.Others;
using Microsoft.EntityFrameworkCore;

namespace FuDever.PostgresSql.Repositories.Auth.ChangingPassword;

internal sealed class ChangingPasswordQuery : IChangingPasswordQuery
{
    private readonly ChangingPasswordStateBag _stateBag;

    internal ChangingPasswordQuery(ChangingPasswordStateBag stateBag)
    {
        _stateBag = stateBag;
    }

    public Task<UserToken> FindUserTokenByResetPasswordTokenQueryAsync(
        string passwordResetToken,
        CancellationToken cancellationToken
    )
    {
        return _stateBag
            .UserTokens.AsNoTracking()
            .Where(predicate: userToken => userToken.Value.Equals(passwordResetToken))
            .Select(selector: userToken => new UserToken { UserId = userToken.UserId })
            .FirstOrDefaultAsync(cancellationToken: cancellationToken);
    }

    public Task<bool> IsResetPasswordTokenFoundByItsValueQueryAsync(
        string passwordResetToken,
        CancellationToken cancellationToken
    )
    {
        return _stateBag.UserTokens.AnyAsync(
            predicate: userToken => userToken.Value.Equals(passwordResetToken),
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
