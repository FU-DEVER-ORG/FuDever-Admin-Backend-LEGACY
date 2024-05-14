using System;
using System.Threading;
using System.Threading.Tasks;
using FuDever.Domain.Repositories.Auth.RequestForgotPassword;
using FuDever.PostgresSql.Commons;
using FuDever.PostgresSql.Repositories.Auth.RequestForgotPassword.Others;
using Microsoft.EntityFrameworkCore;

namespace FuDever.PostgresSql.Repositories.Auth.RequestForgotPassword;

internal sealed class RequestForgotPasswordQuery : IRequestForgotPasswordQuery
{
    private readonly RequestForgotPasswordStateBag _stateBag;

    internal RequestForgotPasswordQuery(RequestForgotPasswordStateBag stateBag)
    {
        _stateBag = stateBag;
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
