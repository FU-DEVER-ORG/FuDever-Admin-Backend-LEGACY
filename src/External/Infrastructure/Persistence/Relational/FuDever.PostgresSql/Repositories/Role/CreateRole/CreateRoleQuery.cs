using System;
using System.Threading;
using System.Threading.Tasks;
using FuDever.Domain.Repositories.Role.CreateRole;
using FuDever.PostgresSql.Commons;
using FuDever.PostgresSql.Repositories.Role.CreateRole.Others;
using Microsoft.EntityFrameworkCore;

namespace FuDever.PostgresSql.Repositories.Role.CreateRole;

internal sealed class CreateRoleQuery : ICreateRoleQuery
{
    private readonly CreateRoleStateBag _stateBag;

    internal CreateRoleQuery(CreateRoleStateBag stateBag)
    {
        _stateBag = stateBag;
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

    public Task<bool> IsRoleTemporarilyRemovedByRoleNameQueryAsync(
        string newRoleName,
        CancellationToken cancellationToken
    )
    {
        var minDateTimeInDatabase = CommonConstant.DbDefaultValue.MIN_DATE_TIME;

        // Linq-Base
        return _stateBag.RoleManager.Roles.AnyAsync(
            predicate: role =>
                EF.Functions.Collate(role.Name, CommonConstant.DbCollation.CASE_INSENSITIVE)
                    .Equals(newRoleName)
                && role.RemovedBy
                    != Application.Shared.Commons.CommonConstant.App.DEFAULT_ENTITY_ID_AS_GUID
                && role.RemovedAt != minDateTimeInDatabase,
            cancellationToken: cancellationToken
        );
    }

    public Task<bool> IsRoleWithTheSameNameFoundByRoleNameQueryAsync(
        string newRoleName,
        CancellationToken cancellationToken
    )
    {
        // Linq-Base
        return _stateBag.RoleManager.Roles.AnyAsync(
            predicate: role =>
                EF.Functions.Collate(role.Name, CommonConstant.DbCollation.CASE_INSENSITIVE)
                    .Equals(newRoleName),
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
