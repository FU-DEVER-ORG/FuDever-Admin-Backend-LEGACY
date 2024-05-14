using System;
using System.Threading;
using System.Threading.Tasks;
using FuDever.Domain.Repositories.Role.RemoveRolePermanentlyByRoleId;
using FuDever.PostgresSql.Commons;
using FuDever.PostgresSql.Repositories.Role.RemoveRolePermanentlyByRoleId.Others;
using Microsoft.EntityFrameworkCore;

namespace FuDever.PostgresSql.Repositories.Role.RemoveRolePermanentlyByRoleId;

internal sealed class RemoveRolePermanentlyByRoleIdQuery : IRemoveRolePermanentlyByRoleIdQuery
{
    private readonly RemoveRolePermanentlyByRoleIdStateBag _stateBag;

    internal RemoveRolePermanentlyByRoleIdQuery(RemoveRolePermanentlyByRoleIdStateBag stateBag)
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

    public Task<bool> IsRoleFoundByRoleIdQueryAsync(
        Guid roleId,
        CancellationToken cancellationToken
    )
    {
        // Linq-Base
        return _stateBag.RoleManager.Roles.AnyAsync(
            role => role.Id == roleId,
            cancellationToken: cancellationToken
        );
    }

    public Task<bool> IsRoleTemporarilyRemovedByRoleIdQueryAsync(
        Guid roleId,
        CancellationToken cancellationToken
    )
    {
        // Linq-Base
        return _stateBag.RoleManager.Roles.AnyAsync(
            role =>
                role.RemovedBy
                    != Application.Shared.Commons.CommonConstant.App.DEFAULT_ENTITY_ID_AS_GUID
                && role.RemovedAt != CommonConstant.DbDefaultValue.MIN_DATE_TIME,
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
