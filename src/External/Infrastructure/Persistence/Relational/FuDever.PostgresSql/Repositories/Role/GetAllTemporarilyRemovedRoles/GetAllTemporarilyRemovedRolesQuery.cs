using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FuDever.Domain.Repositories.Role.GetAllTemporarilyRemovedRoles;
using FuDever.PostgresSql.Commons;
using FuDever.PostgresSql.Repositories.Role.GetAllTemporarilyRemovedRoles.Others;
using Microsoft.EntityFrameworkCore;

namespace FuDever.PostgresSql.Repositories.Role.GetAllTemporarilyRemovedRoles;

internal sealed class GetAllTemporarilyRemovedRolesQuery : IGetAllTemporarilyRemovedRolesQuery
{
    private readonly GetAllTemporarilyRemovedRolesStateBag _stateBag;

    internal GetAllTemporarilyRemovedRolesQuery(GetAllTemporarilyRemovedRolesStateBag stateBag)
    {
        _stateBag = stateBag;
    }

    public async Task<IEnumerable<Domain.Entities.Role>> GetAllTemporarilyRemovedRolesQueryAsync(
        CancellationToken cancellationToken
    )
    {
        // Linq-base
        return await _stateBag
            .RoleManager.Roles.AsNoTracking()
            .Where(predicate: role =>
                role.RemovedAt != CommonConstant.DbDefaultValue.MIN_DATE_TIME
                && role.RemovedBy
                    != Application.Shared.Commons.CommonConstant.App.DEFAULT_ENTITY_ID_AS_GUID
                && role.Id
                    != Application.Shared.Commons.CommonConstant.App.DEFAULT_ENTITY_ID_AS_GUID
            )
            .Select(selector: role => new Domain.Entities.Role
            {
                Id = role.Id,
                Name = role.Name,
                RemovedAt = role.RemovedAt,
                RemovedBy = role.RemovedBy
            })
            .ToListAsync(cancellationToken: cancellationToken);
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
