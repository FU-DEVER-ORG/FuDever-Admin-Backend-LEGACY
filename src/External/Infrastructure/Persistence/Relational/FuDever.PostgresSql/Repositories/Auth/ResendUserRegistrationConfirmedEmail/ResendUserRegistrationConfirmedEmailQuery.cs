using System;
using System.Threading;
using System.Threading.Tasks;
using FuDever.Domain.Repositories.Auth.ResendUserRegistrationConfirmedEmail;
using FuDever.PostgresSql.Commons;
using FuDever.PostgresSql.Repositories.Auth.ResendUserRegistrationConfirmedEmail.Others;
using Microsoft.EntityFrameworkCore;

namespace FuDever.PostgresSql.Repositories.Auth.ResendUserRegistrationConfirmedEmail;

internal sealed class ResendUserRegistrationConfirmedEmailQuery
    : IResendUserRegistrationConfirmedEmailQuery
{
    private readonly ResendUserRegistrationConfirmedEmailStateBag _stateBag;

    internal ResendUserRegistrationConfirmedEmailQuery(
        ResendUserRegistrationConfirmedEmailStateBag stateBag
    )
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
